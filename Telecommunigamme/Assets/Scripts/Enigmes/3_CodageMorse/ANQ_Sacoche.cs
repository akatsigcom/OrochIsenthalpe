using UnityEngine;
using System.Collections;

public class ANQ_Sacoche : MonoBehaviour    // make the bag fall
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
        posFloor = transform.position + new Vector3(0, -4, 0);      // select the end position of bag
    }
    void Update()
    {
        GetPicVertTransform();

        if (picVertTransform.position == ANQ_PicVert.lastPos & transform.position.y > posFloor.y) // If bird reached bag then it drops
        {
            transform.Translate(Vector3.down * Time.deltaTime*sacocheSpeed);
        }
    }
}