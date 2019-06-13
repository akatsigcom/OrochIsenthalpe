using UnityEngine;
using System;
using UnityEngine.UI;

[System.Serializable]
public class UIData
{
    public int timeLinePosition;
    public int timelineSize;
    public int[] events = { };
    public string[] eventDescriptions = { };
    public string[] eventTitles = { };
    public int[] itemID = { };
    public int[] questID = { };
    public string[] questDescriptions = { };
    public string[] questTitles = { };

    public UIData(TimeLine timeline, ObjectManager objects, QuestManager quests)
    {
        timeLinePosition = timeline.timeCount;

        timelineSize = timeline.timeLineSize;

        foreach(Transform child in timeline.unitHolder.transform)
        {
            if (child.GetComponent<EventUnit>() != null)
            {
                Array.Resize(ref events, events.Length + 1);
                events[events.Length - 1] = child.GetSiblingIndex()+1;
            }
        }
        foreach (Transform child in timeline.descriptionHolder.transform)
        {
            Array.Resize(ref eventDescriptions, eventDescriptions.Length + 1);
            eventDescriptions[eventDescriptions.Length - 1] = child.GetChild(0).GetComponent<EventDescription>().GetDescription();
            Array.Resize(ref eventTitles, eventTitles.Length + 1);
            eventTitles[eventTitles.Length - 1] = child.GetChild(0).GetComponent<EventDescription>().GetName();
        }

        foreach(Transform child in quests.questHolder.transform)
        {
            Array.Resize(ref questID, questID.Length + 1);
            questID[questID.Length - 1] = child.GetComponent<Quest>().getID();
            Array.Resize(ref questDescriptions, questDescriptions.Length + 1);
            Array.Resize(ref questTitles, questTitles.Length + 1);
            for (int i = 0; i < child.GetComponent<Text>().text.Length; i++)
            {
                if (child.GetComponent<Text>().text[i].Equals("/") && child.GetComponent<Text>().text[i+1].Equals("n"))
                {
                    questDescriptions[questDescriptions.Length - 1] = child.GetComponent<Text>().text.Substring(0, i-1);
                    questTitles[questTitles.Length - 1] = child.GetComponent<Text>().text.Substring(i+2, child.GetComponent<Text>().text.Length-i-2);
                    break;
                }
            }
            
        }

        foreach (Transform child in objects.objectHolder)
        {
            Array.Resize(ref itemID, itemID.Length + 1);
            itemID[itemID.Length - 1] = child.GetComponent<Item>().ID;
        }

    }


}
