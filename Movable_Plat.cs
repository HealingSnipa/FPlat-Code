using UnityEngine;

public class Movable_Plat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D myRigidbody;
    private Vector2 position;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
       
        
           myRigidbody.linearVelocity = new Vector2(0, 0);
        
       
    }


}
