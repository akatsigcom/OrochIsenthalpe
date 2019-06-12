using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public string[] scenesNames = new string[] { "Scene1working", "_Scene2", "_Scene3" };
    private static int currentScene=0;
    private static int previousScene=-1;
    public GameObject target;
    public GameObject player;
    public GameObject leftCollider;
    public GameObject rightCollider;
    public GameObject Alaia;
    public GameObject Hiro;
    private int sens;
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
        Debug.Log(currentScene);

        SetUp();


    }

    public void SetUp()
       
    {



        if (currentScene > previousScene)
        {
            if (currentScene == 0)
            {
                target.transform.position = new Vector3(leftCollider.transform.position.x + 3f, leftCollider.transform.position.y, leftCollider.transform.position.z);
                player.transform.position = new Vector3(leftCollider.transform.position.x + 3f, leftCollider.transform.position.y, leftCollider.transform.position.z);
                

            }
            else
            {
                target.transform.position = new Vector3(leftCollider.transform.position.x + 4f, leftCollider.transform.position.y, leftCollider.transform.position.z);
                player.transform.position = new Vector3(leftCollider.transform.position.x + 4f, leftCollider.transform.position.y, leftCollider.transform.position.z);
            }
            sens = -1;
            Alaia.transform.position = new Vector3(player.transform.position.x -1f, player.transform.position.y + 1.58f, -1);
            Hiro.transform.position = new Vector3(Alaia.transform.position.x - 0.5f, Alaia.transform.position.y-0.1f, -1);

        }
        else
        {
            if (currentScene == 0)
            {
                target.transform.position = new Vector3(rightCollider.transform.position.x - 1f, rightCollider.transform.position.y, rightCollider.transform.position.z);
                player.transform.position = new Vector3(rightCollider.transform.position.x - 1f, rightCollider.transform.position.y, rightCollider.transform.position.z);
            }
            else
            {
                target.transform.position = new Vector3(rightCollider.transform.position.x - 4f, rightCollider.transform.position.y, rightCollider.transform.position.z);
                player.transform.position = new Vector3(rightCollider.transform.position.x - 4f, rightCollider.transform.position.y, rightCollider.transform.position.z);
            }
            sens = 1;
            Alaia.transform.position = new Vector3(player.transform.position.x + 1f, player.transform.position.y + 1.58f, player.transform.position.z);
            Hiro.transform.position = new Vector3(Alaia.transform.position.x + 0.5f, Alaia.transform.position.y-0.1f, player.transform.position.z);

        }

        Alaia.SetActive(true);
        Hiro.SetActive(true);



    }

    public void NextScene()
    {
        previousScene = currentScene;
        currentScene += 1;
      
        Application.LoadLevel(scenesNames[currentScene]);
    }

    public void PreviousScene()
    {

        previousScene = currentScene;
        currentScene += -1;
        
        Application.LoadLevel(scenesNames[currentScene]);
    }


}
