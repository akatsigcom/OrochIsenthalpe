using UnityEngine;
using System.Collections;

public class ANQ_Sacoche : MonoBehaviour
{
    Vector3 posFloor;

    Transform picVertTransform;
    public int sacocheSpeed;

    void GetPicVertTransform()
    {
        GameObject picVert = GameObject.Find("PicVert");
        if (picVert != null)
        {
            picVertTransform = picVert.transform;
        }
        else
        {
            Debug.Log("PicVert not found");
        }
    }


        private void Start()
    {
        posFloor = transform.position + new Vector3(0, -4, 0);
    }
    void Update()
    {
        GetPicVertTransform();

        if (picVertTransform.position == ANQ_PicVert.lastPos & transform.position.y > posFloor.y)
        {
            transform.Translate(Vector3.down * Time.deltaTime*sacocheSpeed);
        }
    }
}