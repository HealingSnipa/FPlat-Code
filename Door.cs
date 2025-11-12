using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Door : MonoBehaviour
{
    public static Door Instance;
    private Animator myAnimator;
    private BoxCollider2D myCollider;
    [HideInInspector]
    public int CollectiblesCount;
    public Text countText;
    public GameObject winText;
    public int CollectibleNumber = 7;
    private int starting  = 0;
    public GameObject next;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MakeInstance();
        myAnimator = GetComponent<Animator>();  
        myCollider = GetComponent<BoxCollider2D>();
        next.SetActive(false);
        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        starting--;
        if (starting > -5)
        {
            CollectiblesCount = 0;
            countText.text = "Score:" + CollectiblesCount.ToString() + "/" + "7";
        }
        if (CollectiblesCount == 7)
        {
         
            myAnimator.SetBool("open", true);

        }
    }

    void MakeInstance()
    {

        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void DecrementCollectibles()
    {
        CollectiblesCount++;
        countText.text = "Score:" + CollectiblesCount.ToString() + "/7";

        if (CollectiblesCount == 7)
        {
            winText.SetActive(true);
            myCollider.isTrigger = true;
            myAnimator.Play("Door_Open");
            myAnimator.SetBool("open", true);

        }

    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player" && CollectiblesCount > 6)
        {
            next.SetActive(true);
        }
    }

}
