using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANQ_StartButterflies : MonoBehaviour
{
    public GameObject filet;
    // Start is called before the first frame update
    public void OnStartButterfly()
    {
        filet.SetActive(true);
    }
}
