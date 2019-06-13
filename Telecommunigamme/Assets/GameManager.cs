using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool move = true;
    public static GameManager instance = null;
    //public GameObject filet;
    //private bool firstTime = true;
    //private bool butterfly = false;
    public int currentScene;
    private static int colliderNumber = 0;
    private static int previousScene = -1;
    public GameObject target;
    public GameObject player;
    private GameObject currentCollider;
    public GameObject Alaia;
    public GameObject Hiro;
    private int sens;
    public GameObject[] colliderList = new GameObject[] { };

    // Start is called before the first frame update
    
    void Awake()

    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        SetUp();


    }

    public void SetUp()

    {
        //if (currentScene==1 && firstTime)
       // {
           // firstTime = false;
            //butterfly = true;
        //}

        //if (butterfly)
        //{
           // filet.SetActive(true);
        //}

        currentCollider = colliderList[colliderNumber];
        
        if(currentScene<previousScene)
        {
            if (currentScene == 0)
            {
                target.transform.position = new Vector3(currentCollider.transform.position.x - 2f, currentCollider.transform.position.y, currentCollider.transform.position.z);
                player.transform.position = target.transform.position;
            }
            else
            {
            target.transform.position = new Vector3(currentCollider.transform.position.x - 2f,currentCollider.transform.position.y, currentCollider.transform.position.z);
            player.transform.position = target.transform.position;


            }
            sens = 1;
            Alaia.transform.position = new Vector3(player.transform.position.x + 1f, player.transform.position.y + 1.58f, player.transform.position.z);
            Hiro.transform.position = new Vector3(Alaia.transform.position.x + 0.5f, Alaia.transform.position.y - 0.1f, player.transform.position.z);
            
        }
        else
        {
            if (currentScene == 0)
            {
             target.transform.position = new Vector3(currentCollider.transform.position.x + 2f, currentCollider.transform.position.y,currentCollider.transform.position.z);
             player.transform.position = new Vector3(currentCollider.transform.position.x + 2f, currentCollider.transform.position.y, currentCollider.transform.position.z);


            }
            else
            {
            target.transform.position = new Vector3(currentCollider.transform.position.x + 4f, currentCollider.transform.position.y, currentCollider.transform.position.z);
            player.transform.position = player.transform.position = target.transform.position;

            }
            sens = -1;
            Alaia.transform.position = new Vector3(player.transform.position.x - 1f, player.transform.position.y + 1.58f, player.transform.position.z);
            Hiro.transform.position = new Vector3(Alaia.transform.position.x - 0.5f, Alaia.transform.position.y - 0.1f, player.transform.position.z);
            
        }
        player.SetActive(true);
        Alaia.SetActive(true);
        Hiro.SetActive(true);




    }
    private void Update()
    {
        if (!move)
        {
            target.transform.position = player.transform.position;
        }
    }

    public void OnFadeComplete(int numbercol,int levelIndex)
    {
        colliderNumber = numbercol;
        previousScene = currentScene;
        currentScene = levelIndex;
        SceneManager.LoadScene(currentScene);
        
    }

    //public void EndButterFly()
    //{
    //    butterfly = false;
    //    filet.SetActive(false);
    //    SceneManager.LoadScene(currentScene);

    //}
    public void DeactivateMove()
    {
        move = false;
    }

    public void ActivateMove()
    {
        move = true;
    }
}
