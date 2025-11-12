using UnityEngine;

public class bulletSummon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bullet2;

    private int delay = 10;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay--;
        if (Input.GetKeyDown(KeyCode.E) && delay <= 0 && PlayerScript.Instance.theScale.x > 0.1){
            Instantiate(bullet, transform.position, Quaternion.identity);

            delay = 1;
         

        }
        if (Input.GetKeyDown(KeyCode.E) && delay <= 0 && PlayerScript.Instance.theScale.x < 0.1)  {
            Instantiate(bullet2, transform.position, Quaternion.identity);

            delay = 1;

        }
        }
    }
