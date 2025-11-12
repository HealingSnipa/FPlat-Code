using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;



public class bulletLeft : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    private Vector2 position;
    private int wait = 100;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddForce(new Vector2(-60, 0));
    }

    void Update()
    {
        myRigidbody.AddForce(new Vector2(-1, 0));
        wait = wait - 1;
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        
        if (target.gameObject.tag == "Player" ||  target.gameObject.tag == "Ground" || target.gameObject.tag == "deadly")
        {

            Destroy(gameObject);

        }



        if (wait < 0)
        {

            Destroy(gameObject);

        }



    }










}
