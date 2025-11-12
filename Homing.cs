using UnityEngine;

public class Homing : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    private Vector2 position;
    private int left;
    private int down;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if((myRigidbody.position.x - (PlayerScript.Instance.playerRigidbody.position.x-1)) < 1)
        {
            left = 1;
        }
        else
        {
            left = -1;
        }
        if ((myRigidbody.position.y - (PlayerScript.Instance.playerRigidbody.position.y-1)) < 1)
        {
            down = 1;
        }
        else
        {
            down = -1;
        }

        // myRigidbody.linearVelocity = new Vector2(((myRigidbody.position.x - PlayerScript.Instance.playerRigidbody.position.x) * -1/5)+left, ((myRigidbody.position.y - PlayerScript.Instance.playerRigidbody.position.y) * -1/5) - down);
        myRigidbody.linearVelocity = new Vector2(left*3, down*3);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {

        if (target.gameObject.tag == "projectile")
        {
            Destroy(gameObject);
        }
    }
}
