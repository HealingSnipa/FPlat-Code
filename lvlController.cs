using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlController : MonoBehaviour
{

    public void Lvl1()
    {

        SceneManager.LoadScene("SampleScene");
    }

    public void Lvl2()
    {
       
        SceneManager.LoadScene("lvl2");
    }

    public void Lvl3()
    {

        SceneManager.LoadScene("Main_Menu");
    }

   

    public void Kill()
    {
        PlayerScript.Instance.death();
       // SceneManager.LoadScene("Death");

    }

}
