using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class BackgroundFollow : MonoBehaviour
{

    private Rigidbody2D myRigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {


        myRigidbody.linearVelocity = new Vector2(PlayerScript.Instance.playerRigidbody.linearVelocity.x/5, PlayerScript.Instance.playerRigidbody.linearVelocity.y/ 4);
        
    }
}
