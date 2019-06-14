using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ANQ_GoMorse : MonoBehaviour
{
    public void OnClickCodageMorse()
    {
        SceneManager.LoadScene(7);
    }
    public void OnClickDecodageMorse()
    {
        SceneManager.LoadScene(8);
    }
}
