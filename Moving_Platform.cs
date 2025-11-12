using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Moving_Platform : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Vector2 position;
    private int wait = 1000;
    private bool left;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
       

    }

    void Update()
    {
        wait = wait - 1;
        if (wait < 0)
        {
            left = !left;
            wait = 1000;
        }

        if (left == true)
        {
            myRigidbody.linearVelocity = new Vector2(-2, 0);
        }
        if (left == false)
        {
            myRigidbody.linearVelocity = new Vector2(2, 0);
        }
    }

   








}
