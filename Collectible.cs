using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (Door.Instance != null)
        {
            Door.Instance.CollectiblesCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {  
        if (target.tag == "Player") {
            Destroy(gameObject);
            if (Door.Instance != null)
            {

                Door.Instance.DecrementCollectibles();

            }
        }
            
    }


}
