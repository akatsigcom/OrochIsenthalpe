using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
 
    public GameObject quest;
    public GameObject questHolder;
    public GameObject background;
    public GameObject journalManager;


    public void AddQuest(string title, string description, int ID)
    {
        GameObject newQuest = Instantiate(quest, Vector3.zero, Quaternion.identity);
        newQuest.GetComponent<Quest>().setBack(background);
        newQuest.GetComponent<Quest>().setHolder(questHolder);
        newQuest.transform.SetParent(questHolder.transform);
        newQuest.GetComponent<Quest>().setTitle(title);
        newQuest.GetComponent<Quest>().setDescription(description);
        newQuest.GetComponent<Quest>().setID(ID);
        newQuest.GetComponent<Quest>().SetQuest();
        journalManager.GetComponent<Journal>().RefreshPage();
        
    }


    public void FinishQuest(bool isSucceeded, int questID)
    {

        foreach(Transform child in questHolder.transform)
        {
            if(child.GetComponent<Quest>().getID() == questID)
            {
                if (isSucceeded)
                {
                    child.GetComponent<Quest>().setTitle("<color=#00ff00>" + child.GetComponent<Quest>().getTitle() + "</color>");
                    child.GetComponent<Quest>().setDescription("<color=#00ff00>" + child.GetComponent<Quest>().getDescription() + "</color>");
                    child.GetComponent<Quest>().setText();
                }

                else
                {
                    child.GetComponent<Quest>().setTitle("<color=#ff0000>" + child.GetComponent<Quest>().getTitle() + "</color>");
                    child.GetComponent<Quest>().setDescription("<color=#ff0000>" + child.GetComponent<Quest>().getDescription() + "</color>");
                    child.GetComponent<Quest>().setText();
                }

            }
        }
    }


}
