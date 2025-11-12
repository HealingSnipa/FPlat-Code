using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Shield_Summon : MonoBehaviour
{

    [SerializeField]
    private GameObject shield;
  private int delay = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay = delay - 1;
        if (Input.GetKeyDown(KeyCode.Q) && delay < 0)
        {
            Instantiate(shield, transform.position, Quaternion.identity);

            delay = 600;
        }
       
    }
    //sprint
   
   

}
