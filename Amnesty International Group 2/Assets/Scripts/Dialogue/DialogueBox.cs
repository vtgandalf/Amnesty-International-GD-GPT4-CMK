using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public Text DialogueText;
    public Text NameText;
    public TextHandler handler;
    public GameObject optionPanel;
    public Button buttonPrefab;
    Dialogue dialogue;
    int position = 0;
    private bool optionChosen = false;
    private int optionChosenId;
    //private Message response;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = handler.LoadDialogue();
        LoadNextMessage();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChooseAnOption(int x)
    {
        optionChosenId = x;
        optionChosen = true;
        //position ++;
        optionPanel.SetActive(false);
        LoadNextMessage();
    }

    public void LoadNextMessage()
    {
        if (position < dialogue.messages.Length)
        {
            Message message = handler.LoadText(position);
            NameText.text = dialogue.charactersInfo[message.charId].name;
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

            //DialogueText.text = message.text[0];

        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}