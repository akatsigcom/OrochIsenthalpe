using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class managerNext : MonoBehaviour
{

    //public GameObject Button;
    private void OnTriggerEnter2D(Collider2D col)
    { if (col.name=="player") {
            GameManager.instance.NextScene();
        } }
}

