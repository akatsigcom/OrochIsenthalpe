using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public GameObject journal;
    public GameObject quests;
    public GameObject journalEntries;
    public GameObject telecomStuff;
    public int page;
    private int questPage = 6;
    private int journalPage = 1;
    private int telecomPage = 3;


    public void OnClick()
    {
        journal.SetActive(true);
        page = 0;
        OpenPage(page);
    }

    public void Exit()
    {
        journal.SetActive(false);
        telecomStuff.SetActive(false);
        journalEntries.SetActive(false);
        quests.SetActive(false);
    }

    public void RefreshPage()
    {
        OpenPage(page);
    }

    public void OpenPage(int pageNumber)
    {
        int totalPageNumber = questPage + ((int)quests.transform.childCount / 8);
        if (pageNumber < telecomPage && pageNumber >=0)
        {
            telecomStuff.SetActive(false);
            journalEntries.SetActive(true);
            quests.SetActive(false);


        }
        else if(pageNumber < questPage && pageNumber >= 0)
        {
            telecomStuff.SetActive(true);
            journalEntries.SetActive(false);
            quests.SetActive(false);


        }
        else if(pageNumber <= totalPageNumber && pageNumber >= 0)
        {
            int questNumber = quests.transform.childCount;
            telecomStuff.SetActive(false);
            journalEntries.SetActive(false);
            quests.SetActive(true);

            foreach (Transform child in quests.transform)
            {
                if((pageNumber - questPage) * 8 <= child.GetSiblingIndex() && child.GetSiblingIndex() < ((pageNumber - questPage) * 8) + 8 )
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if(pageNumber < 0)
            {
                page = totalPageNumber;
                OpenPage(page);
            }
            else
            {
                page = 0;
                OpenPage(page);
            }
        }
    }

    public void NextPage()
    {
        page++;
        OpenPage(page);
    }

    public void PreviousPage()
    {
        page--;
        OpenPage(page);
    }

    public void OpenQuests()
    {
        telecomStuff.SetActive(false);
        journalEntries.SetActive(false);
        page = questPage;

        if (quests.transform.childCount > 8)
        {
            foreach(Transform child in quests.transform)
            {
                if (child.GetSiblingIndex() < 8)
                {
                    child.gameObject.SetActive(true);
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            quests.SetActive(true);
        }
    }

    public void OpenJournal()
    {
        telecomStuff.SetActive(false);
        journalEntries.SetActive(true);
        quests.SetActive(false);
        page = journalPage;
    }

    public void OpenTelecom()
    {
        telecomStuff.SetActive(true);
        journalEntries.SetActive(false);
        quests.SetActive(false);
        page = telecomPage;
    }



}


