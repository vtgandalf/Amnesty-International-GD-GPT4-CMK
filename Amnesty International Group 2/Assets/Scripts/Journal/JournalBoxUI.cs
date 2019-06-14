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
    private Tabs currentTab = Tabs.Quests;
    private int pageIndex = 0;
    public JournalData journalData;
    public float tabExpandValue = 0.5f;
    public float normalButtonHeight;
    public Button relevantButton;
    public Button storiesButton;
    public Button questsButton;
    private Button previousChosenTabButton;
    void Start()
    {
        if (relevantButton != null)
        {
            normalButtonHeight = relevantButton.image.rectTransform.sizeDelta.y;
        }
        SetTabToRelevant();
        journalData.UpdateLists();
        RefreshPages();
    }

    void OnEnable()
    {
        RefreshPages();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTabToRelevant()
    {
        if (currentTab != Tabs.Relevant)
        {
            currentTab = Tabs.Relevant;
            SetTab(relevantButton);
            if (previousChosenTabButton != null)
            {
                ReSetTab(previousChosenTabButton);
            }
            previousChosenTabButton = relevantButton;
            pageIndex = 0;
            titleOfPage1.SetActive(false);
            titleOfPage2.SetActive(false);
            RefreshPages();
        }
    }

    public void SetTabToQuests()
    {
        if (currentTab != Tabs.Quests)
        {
            currentTab = Tabs.Quests;
            SetTab(questsButton);
            if (previousChosenTabButton != null)
            {
                ReSetTab(previousChosenTabButton);
            }
            previousChosenTabButton = questsButton;
            pageIndex = 0;
            titleOfPage1.SetActive(false);
            titleOfPage2.SetActive(false);
            RefreshPages();
        }
    }

    public void SetTabToStories()
    {
        if (currentTab != Tabs.Stories)
        {
            currentTab = Tabs.Stories;
            SetTab(storiesButton);
            if (previousChosenTabButton != null)
            {
                ReSetTab(previousChosenTabButton);
            }
            previousChosenTabButton = storiesButton;
            pageIndex = 0;
            titleOfPage1.SetActive(true);
            titleOfPage2.SetActive(true);
            RefreshPages();
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
    private void RefreshPages()
    {
        try
        {
            DisplayText();
        }
        catch
        {
            titleOfPage1.GetComponent<Text>().text = " ";
            titleOfPage2.GetComponent<Text>().text = " ";
            textOfPage1.text = " ";
            textOfPage2.text = " ";
        }
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
    private void SetTab(Button tab)
    {
        float diff = tab.image.rectTransform.sizeDelta.y * tabExpandValue;
        tab.image.rectTransform.sizeDelta = new Vector2(tab.image.rectTransform.sizeDelta.x, (tab.image.rectTransform.sizeDelta.y + diff));
        Vector2 position = new Vector2(tab.image.rectTransform.position.x, (tab.image.rectTransform.position.y + diff));
        tab.image.rectTransform.position = position;
    }

    private void ReSetTab(Button tab)
    {
        tab.image.rectTransform.sizeDelta = new Vector2(tab.image.rectTransform.sizeDelta.x, normalButtonHeight);
        Vector2 position = new Vector2(tab.image.rectTransform.position.x, (tab.image.rectTransform.position.y - (normalButtonHeight * tabExpandValue)));
        tab.image.rectTransform.position = position;
    }
}

