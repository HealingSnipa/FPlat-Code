using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerScript : MonoBehaviour
{
    //DECLARE VARIABLES
    private Rigidbody2D myRigidbody;
    public Rigidbody2D playerRigidbody;

    public Animator myAnimator;
    public float movementSpeed;
    public bool facingRight;
    public Vector3 theScale;
    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;
    private bool jump;
    [SerializeField]
    private float jumpForce;
    private bool dead = false;
    public GameObject reset;

    //custom
    public static PlayerScript Instance;
    public float flyTime = 100;
    public bool flying;
    private int jumpNumber = 2;
    private float sprintCooldown = 100;
    private float sprintStrength = 100;
    private float maxSprintDuration = 10;
    private float sprintDuration = 10;
    private int deathWait = 1000;
    public GameObject DeathScreen;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        sprintDuration = maxSprintDuration;
        sprintDuration = maxSprintDuration;
        reset.SetActive(false);
        theScale.x = 1;
    MakeInstance();
        DeathScreen.SetActive(false);
    }




    // Update is called once per frame
    void Update()
    {

        HandleInput();
        if(dead == true) {


            deathWait--;
            if (deathWait < 0 && Door.Instance.CollectiblesCount < 7)
            {
                DeathScreen.SetActive(true);
            }

        }
}

void FixedUpdate()
    {

        playerRigidbody = myRigidbody;

        sprintCooldown--;
            if (sprintCooldown < 0)
            {
                sprintDuration = maxSprintDuration;
            }
           
            float horiztontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
        if (dead == false)
        {
            handleMovement(horiztontal);
        // handleMovementY(vertical);


        //  if (vertical > 0.01 || vertical < -0.01 && flying == false)
        //  {
        //     flyTime = flyTime - 1;
        //  }
        //  if (vertical > 0.01 || vertical < -0.01)
        //{
        //        flying = false;
        //    }
        //        if (flyTime < -30)
        //   {
        //      if (vertical < 0.01 && vertical > -0.01) {
        //        flying = false;
        //        flyTime = 100;
        //  }
        //     }


       
            Flip(horiztontal);
            isGrounded = IsGrounded();
        }
    }

    //FUNCTION DEFINTIONS
    private void handleMovement(float horizontal)
    {
        
            bool isShiftKeyDown = Input.GetKey(KeyCode.LeftShift);
            if (!isShiftKeyDown || sprintDuration < 0.1)
            {
                myRigidbody.linearVelocity = new Vector2(horizontal * movementSpeed, myRigidbody.linearVelocityY);
            }

            myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

            //SPRINT

            if (isShiftKeyDown && sprintDuration > 0.1)
            {
                myRigidbody.linearVelocity = new Vector2(horizontal * 1 * (sprintStrength / 10), 0);
                sprintCooldown = 200;
                sprintDuration--;
                myAnimator.SetBool("sprinting", true);
            }


            if (jump && jumpNumber > 0.1)
            {
                //test
                if (myRigidbody.linearVelocityY < 0)
                {
                    myRigidbody.linearVelocity = new Vector2(horizontal * movementSpeed, 0);
                }

                //doublejump
                isGrounded = false;
                jump = false;
                jumpNumber = jumpNumber - 1;
                myRigidbody.AddForce(new Vector2(0, jumpForce));
            }
        
    }
    //sprint
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpNumber > 0.1) {
            jump = true;
            myAnimator.SetBool("jumping", true);
        }
    }



    //TEST
    //private void handleMovementY(float vertical)
    //
    //if (flyTime > 0)
    //{
    //    myRigidbody.linearVelocity = new Vector2(myRigidbody.linearVelocityX, vertical * movementSpeed-1);
    //    myAnimator.SetFloat("Vspeed", vertical);

    // }
    // }

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight)
        {
            facingRight = !facingRight;
            theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }


    private bool IsGrounded()
    {
        if (myRigidbody.linearVelocity.y <= 0)
        {
            //if player is not moving vertically, test each of Player's groundPoints for collision with Ground
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; 1 < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            myAnimator.SetBool("jumping", false);
            jumpNumber = 2;
        }


        if (target.gameObject.tag == "deadly")
        {
            death();

        }


    }

    public void death()
    {

        myAnimator.SetBool("dead", true);
        dead = true;
        reset.SetActive(true);
    }

    void MakeInstance()
    {

        if (Instance == null)
        {
            Instance = this;
        }
    }
}
