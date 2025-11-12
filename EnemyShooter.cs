using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    public GameObject bullet;
    [SerializeField]
    private int delay = 100;
    private Animator myAnimator;
    public Vector2 theScale;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per
    void FixedUpdate()
    {
        delay--;
        if (delay <= 0)
        {
            Instantiate(bullet,transform.position, Quaternion.identity);

            delay = 100;
            myAnimator.SetBool("shooting", true);

        }

        if (delay <= 80 && delay > 70)
        {
           
            myAnimator.SetBool("shooting", false);

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
