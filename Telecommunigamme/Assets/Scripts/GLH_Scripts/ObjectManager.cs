using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] objectList;

    public Transform objectHolder;

    public void PickUpObject(int objectID)
    {
        int objectNumber = objectHolder.childCount;
        Vector3 objectPosition = new Vector3(0.95f*Screen.width ,0.75f*Screen.height - objectNumber*objectList[0].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta[1] ,0);

        GameObject newObject = Instantiate(objectList[objectID], objectPosition, Quaternion.identity);
        newObject.transform.SetParent(objectHolder);
    }


    public void DiscardObject(int objectID)
    {
        foreach(Transform child in objectHolder)
        {
            if(child.GetComponent<Item>().ID == objectID)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
