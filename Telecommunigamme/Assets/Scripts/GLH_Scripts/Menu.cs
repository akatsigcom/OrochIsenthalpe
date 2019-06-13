using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuHolder;
    public GameObject timeline;
    public GameObject objects;
    public GameObject quests;
    private int time;

    public void MainMenu()
    {
        MenuHolder.SetActive(true);
        GameManager.instance.DeactivateMove();
    }

    public void Resume()
    {
        MenuHolder.SetActive(false);
        GameManager.instance.ActivateMove();
    }

        public void Save()
    {
        UISaveSystem.SaveUI(timeline.GetComponent<TimeLine>(), objects.GetComponent<ObjectManager>(), quests.GetComponent<QuestManager>());
    }

    public void Options()
    {

    }

    public void Load()
    {
        UIData data = UISaveSystem.LoadUI();
        
        timeline.GetComponent<TimeLine>().SetTimelineSize(data.timelineSize);
        timeline.GetComponent<TimeLine>().GenerateTimeline();

        if (data.events != null)
        {
            int i = 0;
            foreach (int child in data.events)
            {
                timeline.GetComponent<TimeLine>().AddEvent(child, data.eventTitles[i], data.eventDescriptions[i]);
                i++;
            }
        }
        
        if(data.questID != null)
        {
            int i = 0;
            foreach (int child in data.questID)
            {
                quests.GetComponent<QuestManager>().AddQuest(data.questTitles[i], data.questDescriptions[i], data.questID[i]);
                i++;
            }
        }
        
        if(data.itemID != null)
        {
            foreach (int child in data.itemID)
            {
                objects.GetComponent<ObjectManager>().PickUpObject(child);
            }
        }

        time = data.timeLinePosition;
        StartCoroutine(TimeForward());
        
        

    }

    public void Training()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }


    private IEnumerator TimeForward()
    {
        for (int i = 0; i < time; i++)
        {
            timeline.GetComponent<TimeLine>().TimeForward();
            yield return new WaitForSeconds(0.01f);
        }
    }

}
