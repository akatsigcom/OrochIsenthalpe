using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    private string title;
    private string description;
    public GameObject questHolder;
    public GameObject background;
    public int spacing = 10;
    private int questID;


    public void setHolder(GameObject holder)
    {
        questHolder = holder;
    }

    public void setBack(GameObject back)
    {
        background = back;
    }


    public void setID(int ID)
    {
        questID = ID;
    }

    public int getID()
    {
        return questID;
    }

    public void setTitle(string questTitle)
    {
        title = questTitle;
    }

    public void setDescription(string questDescription)
    {
        description = questDescription;
    }

    public string getTitle()
    {
        return title;
    } 

    public string getDescription()
    {
        return description;
    }

    public void setText()
    {
        this.GetComponent<Text>().text = "<size=35><b>" + title + "</b></size>\n" + "<size=25>" + description + "</size>";
    }


    public void SetQuest()
    {
        Vector3[] corners = new Vector3[4];
        background.GetComponent<RectTransform>().GetWorldCorners(corners);
        Vector3 initialPosition = RectTransformUtility.WorldToScreenPoint(null, corners[1]) + new Vector2((this.gameObject.GetComponent<RectTransform>().sizeDelta[0]/3f), -(this.gameObject.GetComponent<RectTransform>().sizeDelta)[1]/2f) ;
        this.GetComponent<Text>().text = "<size=35><b>" + title + "</b></size>\n" + "<size=25>" + description + "</size>";

        int questNumber = questHolder.transform.childCount;
        if(questNumber%8 == 1)
        {
            this.GetComponent<RectTransform>().position = initialPosition;
        }
        else if(questNumber % 8 == 2)
        {
            this.GetComponent<RectTransform>().position = initialPosition + new Vector3(0, -this.GetComponent<RectTransform>().sizeDelta[1]/2f - spacing, 0);
        }
        else if (questNumber % 8 == 3)
        {
            this.GetComponent<RectTransform>().position = initialPosition + 2f*(new Vector3(0, -this.GetComponent<RectTransform>().sizeDelta[1]/2f - spacing, 0));
        }
        else if (questNumber % 8 == 4)
        {
            this.GetComponent<RectTransform>().position = initialPosition + 3f*(new Vector3(0, -this.GetComponent<RectTransform>().sizeDelta[1]/2f - spacing, 0));
        }
        else if (questNumber % 8 == 5)
        {
            this.GetComponent<RectTransform>().position = initialPosition + new Vector3(background.GetComponent<RectTransform>().sizeDelta[0]/2f - (this.gameObject.GetComponent<RectTransform>().sizeDelta[0] / 3f), 0, 0);
        }
        else if (questNumber % 8 == 6)
        {
            this.GetComponent<RectTransform>().position = initialPosition + new Vector3((background.GetComponent<RectTransform>().sizeDelta[0] / 2f) - (this.gameObject.GetComponent<RectTransform>().sizeDelta[0] / 3f), -this.GetComponent<RectTransform>().sizeDelta[1]/2f - spacing, 0);
        }
        else if (questNumber % 8 == 7)
        {
            this.GetComponent<RectTransform>().position = initialPosition + new Vector3(background.GetComponent<RectTransform>().sizeDelta[0] / 2f - (this.gameObject.GetComponent<RectTransform>().sizeDelta[0] / 3f), 2f *(-this.GetComponent<RectTransform>().sizeDelta[1])/2f - spacing, 0);
        }
        else
        {
            this.GetComponent<RectTransform>().position = initialPosition + new Vector3(background.GetComponent<RectTransform>().sizeDelta[0] / 2f - (this.gameObject.GetComponent<RectTransform>().sizeDelta[0] / 3f), 3f*(-this.GetComponent<RectTransform>().sizeDelta[1])/2f - spacing, 0);
        }
    }
}
