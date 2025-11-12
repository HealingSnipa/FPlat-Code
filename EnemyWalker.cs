using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    [SerializeField]
    private Transform startPos, endPos;
    public bool collision;
    public float speed = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }

    private void Move()
    {
        myRigidbody.linearVelocity = new Vector2(transform.localScale.x, 0) * speed;


    }



    void ChangeDirection()
    {
        //this monitors the contact between the walker and a layer called Ground.
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));

        //if there is no collision between the walker and the ground, then this changes the walker's direction
        if (!collision)
        {
            Vector3 temp = transform.localScale;
            if (temp.x == 1)
            {
                temp.x = -1f;
            }
            else
            {
                temp.x = 1f;
            }
            transform.localScale = temp;
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    { 

        if (target.gameObject.tag == "projectile")
        {
            Destroy(gameObject);
        }
    }

}
