using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLine : MonoBehaviour
{
    public Transform timeUnit; //base bloc for the timeline
    public Transform timeUnitFilled; //same but filled
    public Transform eventUnit; //base event bloc
    public Transform passedEventUnit; //same but already realized
    public GameObject eventText; //the description zone of the events
    public GameObject unitHolder; //to organize the units
    public GameObject descriptionHolder; //to organize descirptions
    public int timeLineSize = 5; //number of blocs in the timeline
    public float unitProportionalHeigth = 0.15f; //height of blocs, proportional to screen size
    private float beginning = 0.1f * Screen.width;
    private float ending = 0.9f * Screen.width;
    private float lineHeight = 0.75f * Screen.height;
    public int timeCount; //int to know were the player is timewise


    public void SetTimelineSize(int size)
    {
        timeLineSize = size;
    }


    public void GenerateTimeline() //to generate a new timeline. You have to change the size before doing that (5 by default)
    {
        timeCount = 0;
        float unitInitialWidth = timeUnit.GetComponent<SpriteRenderer>().bounds.size.x;
        float unitInitialHeigth = timeUnit.GetComponent<SpriteRenderer>().bounds.size.y;
        Vector3 unitScale = new Vector3(((ending - beginning) / timeLineSize) / (unitInitialWidth), unitProportionalHeigth*Screen.height / unitInitialHeigth, 1);

        DestroyTimeline();
        //creation of the units
        for (int i = 0; i < timeLineSize; i++)
        {
            Vector2 unitPosition = new Vector2(beginning + i*(unitInitialWidth*unitScale.x) + unitInitialWidth*(unitScale.x-1)/2, lineHeight);
            Transform newUnit = Instantiate(timeUnit, unitPosition, Quaternion.identity);
            newUnit.localScale = new Vector3(unitScale.x, unitScale.y, unitScale.z);
            newUnit.SetParent(unitHolder.transform);
        }
    }

    public void TimeForward() //to advance of one unit in the timeline
    {
        Transform memory = unitHolder.transform.GetChild(timeCount);

        if (unitHolder.transform.GetChild(timeCount).gameObject.name == "time unit empty(Clone)")
        {
            
            Destroy(unitHolder.transform.GetChild(timeCount).gameObject);

            Transform newUnit = Instantiate(timeUnitFilled, memory.position, memory.rotation);
            newUnit.localScale = memory.localScale;
            newUnit.SetParent(unitHolder.transform);
            newUnit.SetSiblingIndex(timeCount);
            timeCount++;
        }
        else if(unitHolder.transform.GetChild(timeCount).gameObject.name == "event unit(Clone)")
        {            
            Destroy(unitHolder.transform.GetChild(timeCount).gameObject);

            Transform newUnit = Instantiate(passedEventUnit, memory.position, memory.rotation);
            newUnit.localScale = memory.localScale;
            newUnit.SetParent(unitHolder.transform);
            newUnit.SetSiblingIndex(timeCount);
            timeCount++;

            foreach (Transform child in descriptionHolder.transform)
            {
                if(child.GetChild(0).GetComponent<EventDescription>().GetTime() == timeCount)
                {
                    newUnit.GetComponent<EventUnit>().SetPanel(child.gameObject);
                }
            }            
        }
        else
        {
            Debug.LogError("Problem bitch");
        }
        
    }

    public void TimeBackward() //same but backward
    {
        Transform memory = unitHolder.transform.GetChild(timeCount-1);
        Destroy(unitHolder.transform.GetChild(timeCount-1).gameObject);

        Transform newUnit = Instantiate(timeUnit, memory.position, memory.rotation);
        newUnit.localScale = memory.localScale;
        newUnit.SetParent(unitHolder.transform);
        newUnit.SetSiblingIndex(timeCount-1);
        timeCount--;
    }

    public int GetTimeCount() //if you want toknow where the player is timewise
    {
        return timeCount;
    }

    public void DestroyTimeline() //if it's needed to erase the timeline (it does it automatically at the generation too)
    {
        foreach (Transform child in unitHolder.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in descriptionHolder.transform)
        {
            Destroy(child.gameObject);
        }
    }


    public void AddEvent(int eventTime, string eventName, string eventDescription)
    {
        Transform memory = unitHolder.transform.GetChild(eventTime - 1);
        Destroy(unitHolder.transform.GetChild(eventTime-1).gameObject);
        if(timeCount < eventTime)
        {
            Transform newEventUnit = Instantiate(eventUnit, memory.position, memory.rotation);
            newEventUnit.localScale = memory.localScale;
            newEventUnit.SetParent(unitHolder.transform);
            newEventUnit.SetSiblingIndex(eventTime - 1);
            Vector3 eventTextPosition = memory.position + new Vector3(0, -unitProportionalHeigth * Screen.height * 3 / 4, 0);
            GameObject newEventText = Instantiate(eventText, eventTextPosition, Quaternion.identity);
            newEventUnit.transform.GetComponent<EventUnit>().SetPanel(newEventText);
            newEventText.SetActive(false);
            newEventText.transform.SetParent(descriptionHolder.transform);
            newEventText.transform.GetChild(0).GetComponent<EventDescription>().SetTitle(eventName);
            newEventText.transform.GetChild(0).GetComponent<EventDescription>().SetDescription(eventDescription);
            newEventText.transform.GetChild(0).GetComponent<EventDescription>().SetTime(eventTime);
            newEventText.transform.GetChild(0).GetComponent<EventDescription>().SetText();
            newEventText.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0.8f * Screen.width / timeLineSize, unitProportionalHeigth * Screen.height);
            newEventText.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.75f * Screen.width / timeLineSize, (unitProportionalHeigth - 0.02f) * Screen.height);
        }
        else
        {
            Transform newEventUnit = Instantiate(passedEventUnit, memory.position, memory.rotation);
            newEventUnit.localScale = memory.localScale;
            newEventUnit.SetParent(unitHolder.transform);
            newEventUnit.SetSiblingIndex(eventTime - 1);
            Vector3 eventTextPosition = memory.position + new Vector3(0, -unitProportionalHeigth * Screen.height * 3 / 4, 0);
            GameObject newEventText = Instantiate(eventText, eventTextPosition, Quaternion.identity);
            newEventUnit.transform.GetComponent<EventUnit>().SetPanel(newEventText);
            newEventText.SetActive(false);
            newEventText.transform.SetParent(descriptionHolder.transform);
            newEventText.transform.GetChild(0).gameObject.GetComponent<EventDescription>().SetTitle(eventName);
            newEventText.transform.GetChild(0).gameObject.GetComponent<EventDescription>().SetDescription(eventDescription);
            newEventText.transform.GetChild(0).gameObject.GetComponent<EventDescription>().SetTime(eventTime);
            newEventText.transform.GetChild(0).gameObject.GetComponent<EventDescription>().SetText();
            newEventText.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0.8f * Screen.width / timeLineSize, unitProportionalHeigth * Screen.height);
            newEventText.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.75f * Screen.width / timeLineSize, (unitProportionalHeigth - 0.02f) * Screen.height);
        }  
    }


    public void DeleteEvent(int eventTime)
    {
        Transform memory = unitHolder.transform.GetChild(eventTime - 1);
        Destroy(unitHolder.transform.GetChild(eventTime - 1).gameObject);
        if(timeCount >= eventTime)
        {
            Transform newUnit = Instantiate(timeUnitFilled, memory.position, memory.rotation);
            newUnit.localScale = memory.localScale;
            newUnit.SetParent(unitHolder.transform);
            newUnit.SetSiblingIndex(eventTime - 1);
        }
        else
        {
            Transform newUnit = Instantiate(timeUnit, memory.position, memory.rotation);
            newUnit.localScale = memory.localScale;
            newUnit.SetParent(unitHolder.transform);
            newUnit.SetSiblingIndex(eventTime - 1);
        }
        

        foreach (Transform child in descriptionHolder.transform)
        {
            if (child.transform.GetChild(0).GetComponent<EventDescription>().GetTime() == eventTime)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
