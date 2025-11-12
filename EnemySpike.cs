
using System.Collections;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;


public class EnemySpike : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    private Animator myAnimator;
    private float jumpHeight;
    private float forceY;
    public float wait = 100;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        forceY = myRigidBody.linearVelocityY;
        myAnimator.SetFloat("forceY", forceY);
        wait--;
        if(wait < 0)
        {
            myRigidBody.AddForce(new Vector2(0, 400));
            wait = 300;
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
