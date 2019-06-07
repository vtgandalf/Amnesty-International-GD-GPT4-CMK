using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum Tabs
{
    Relevant,
    Stories,
    Quests
}
public class JournalBoxUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textOfPage1;
    public Text textOfPage2;
    public GameObject titleOfPage1;
    public GameObject titleOfPage2;
    private Tabs currentTab = Tabs.Relevant;
    private int pageIndex = 0;
    public JournalData journalData;
    void Start()
    {
        journalData.UpdateLists();
        try
        {
            DisplayText();
        }
        catch
        {
            titleOfPage1.GetComponent<Text>().text = "";
            titleOfPage2.GetComponent<Text>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTabToRelevant()
    {
        currentTab = Tabs.Relevant;
        pageIndex = 0;
        titleOfPage1.SetActive(false);
        titleOfPage2.SetActive(false);
        try
        {
            DisplayText();
        }
        catch
        {
            titleOfPage1.GetComponent<Text>().text = "";
            titleOfPage2.GetComponent<Text>().text = "";
        }
    }

    public void SetTabToQuests()
    {
        currentTab = Tabs.Quests;
        pageIndex = 0;
        titleOfPage1.SetActive(false);
        titleOfPage2.SetActive(false);
        try
        {
            DisplayText();
        }
        catch
        {
            titleOfPage1.GetComponent<Text>().text = "";
            titleOfPage2.GetComponent<Text>().text = "";
        }
    }

    public void SetTabToStories()
    {
        currentTab = Tabs.Stories;
        pageIndex = 0;
        titleOfPage1.SetActive(true);
        titleOfPage2.SetActive(true);
        try
        {
            DisplayText();
        }
        catch
        {
            titleOfPage1.GetComponent<Text>().text = "";
            titleOfPage2.GetComponent<Text>().text = "";
        }
    }

    public void GoToNextPage()
    {
        int length = 0;
        switch (currentTab)
        {
            case Tabs.Relevant:
                length = journalData.Notes.Count;
                break;

            case Tabs.Stories:
                length = journalData.Stories.Count;
                break;

            case Tabs.Quests:
                length = journalData.Objectves.Count;
                break;

            default:
                break;
        }
        if (pageIndex + 2 <= length - 1)
        {
            pageIndex = pageIndex + 2;
            DisplayText();
        }
    }

    public void GoToPreviousPage()
    {
        if (pageIndex - 2 >= 0)
        {
            pageIndex = pageIndex - 2;
        }
        DisplayText();
    }

    private void DisplayText()
    {
        string text1 = null;
        string text2 = null;
        titleOfPage1.GetComponent<Text>().text = null;
        titleOfPage2.GetComponent<Text>().text = null;
        switch (currentTab)
        {
            case Tabs.Relevant:
                if (journalData.Notes[pageIndex] != null)
                {
                    text1 = journalData.Notes[pageIndex].Entry;
                }
                if (pageIndex + 1 <= journalData.Notes.Count - 1 && journalData.Notes[pageIndex + 1] != null)
                {
                    text2 = journalData.Notes[pageIndex + 1].Entry;
                }
                break;

            case Tabs.Stories:
                if (journalData.Stories[pageIndex] != null)
                {
                    text1 = journalData.Stories[pageIndex].Entry;
                    titleOfPage1.GetComponent<Text>().text = journalData.Stories[pageIndex].Name;
                }
                if (pageIndex + 1 <= journalData.Stories.Count - 1 && journalData.Stories[pageIndex + 1] != null)
                {
                    text2 = journalData.Stories[pageIndex + 1].Entry;
                    titleOfPage2.GetComponent<Text>().text = journalData.Stories[pageIndex + 1].Name;
                }
                break;

            case Tabs.Quests:
                if (journalData.Objectves[pageIndex] != null)
                {
                    text1 = journalData.Objectves[pageIndex].Entry;
                }
                if (pageIndex + 1 <= journalData.Objectves.Count - 1 && journalData.Objectves[pageIndex + 1] != null)
                {
                    text2 = journalData.Objectves[pageIndex + 1].Entry;
                }
                break;

            default:
                break;
        }
        textOfPage1.text = text1;
        textOfPage2.text = text2;
    }
}
