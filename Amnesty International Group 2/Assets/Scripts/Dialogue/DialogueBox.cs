﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public Text DialogueText;
    public Text NameText;
    public TextHandler handler;
    public GameObject optionPanel;
    public GameObject mainPanel;
    public Button buttonPrefab;
    Dialogue dialogue;
    int position = 0;
    private bool optionChosen = false;
    private int optionChosenId;
    //private int storyChosenId;
    private bool hasAStory = false;
    private bool hasInfo = false;

    public JournalData journal;
    //private Message response;
    // Start is called before the first frame update
    public DialogueEventCaller dialogEC;
    void Start()
    {
        mainPanel.SetActive(false);
        dialogEC.DialogueEvent.AddListener(StartConversation);
    }

    public void StartConversation(Dialogue DiAlOgE)
    {
        if(dialogEC.Dialogging)
        {
            return;
        }
        dialogEC.Dialogging=true;
        mainPanel.SetActive(true);
        handler.dialogue = DiAlOgE;
        dialogue = handler.LoadDialogue();
        position = 0;
        LoadNextMessage();
        foreach (JournalEntry x in dialogue.notes)
        {
            switch (x.JEType)
            {
                case JournalEntryType.STORY:
                    hasAStory = true;
                    break;

                case JournalEntryType.OBJECTIVE:
                    hasInfo = true;
                    break;

                case JournalEntryType.NOTE:
                    hasInfo = true;
                    break;

                default:
                    break;
            }
        }
    }
    public void ChooseAnOption(int x)
    {
        for (int i = 0; i < optionPanel.transform.childCount; i++)
        {
            var child = optionPanel.transform.GetChild(i).gameObject;
            if (child != null)
                child.SetActive(false);
        }
        optionChosenId = x;
        optionChosen = true;
        optionPanel.SetActive(false);
        LoadNextMessage();
    }

    public void ChooseAStory(JournalEntry x)
    {
        journal.AddEntry(x);
        optionPanel.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void LoadNextMessage()
    {
        if (position < dialogue.messages.Length)
        {
            Message message = handler.LoadText(position);
            try
            {
                NameText.text = dialogue.charactersInfo[message.charId].name;
            }
            catch
            {
                NameText.text = " ";
            }
            // check if there is only one message
            if (message.text.Length > 1 && !optionChosen)
            {
                optionPanel.SetActive(true);
                // if there are more than one
                // creare n number of elements from text type
                for (int i = 0; i < message.text.Length; i++)
                {
                    // create a button
                    Button button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);
                    // set its text
                    var btnText = button.GetComponentInChildren<Text>();
                    btnText.text = message.text[i];
                    //button.text = message.text[i];
                    // set its function
                    button.onClick.AddListener(() => { ChooseAnOption(i - 1); });
                    // set the parent to be the optionPanel
                    button.transform.SetParent(optionPanel.transform);
                }
                // display the text into the buttons
            }
            if (message.text.Length == 1)
            {
                position++;
                DialogueText.text = message.text[0];
                optionPanel.SetActive(false);
            }
            if (optionChosen)
            {
                Debug.Log(optionChosenId);
                DialogueText.text = message.text[optionChosenId];
                position++;
                optionChosen = false;
            }

        }
        else
        {
            AddAditionalInformationToJournal();
            ChooseAStoryToAddToJournal();
            mainPanel.SetActive(false);
        }
    }

    private void ChooseAStoryToAddToJournal()
    {
        NameText.text = "Choose what to write down!";
        foreach (JournalEntry x in dialogue.notes)
        {
            if (x.JEType == JournalEntryType.STORY)
            {
                if (!optionPanel.activeSelf)
                {
                    optionPanel.SetActive(true);
                }
                // create a button
                Button button = Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity);
                // set its text
                var btnText = button.GetComponentInChildren<Text>();
                btnText.text = x.Name;
                //button.text = message.text[i];
                // set its function
                button.onClick.AddListener(() => { ChooseAStory(x); });
                // set the parent to be the optionPanel
                button.transform.SetParent(optionPanel.transform);
            }
        }
    }

    private void AddAditionalInformationToJournal()
    {
        if (hasInfo)
        {
            foreach (JournalEntry x in dialogue.notes)
            {
                switch (x.JEType)
                {
                    case JournalEntryType.OBJECTIVE:
                        journal.AddEntry(x);
                        break;

                    case JournalEntryType.NOTE:
                        journal.AddEntry(x);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}