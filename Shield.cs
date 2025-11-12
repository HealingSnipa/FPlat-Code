using UnityEngine;

public class Shield : MonoBehaviour
{
   private int wait = 300;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wait--;
        if (wait < 0)
        {
            Destroy(gameObject);
          
        }
    }
}
