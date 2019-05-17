using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    public Text DialogueText;
    public Text NameText;
    public TextHandler handler;
    Dialogue dialogue;
    int position = 0;
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

    public void LoadNextMessage(){
        if (position < dialogue.messages.Length){
            Message message = handler.LoadText(position);
            NameText.text = dialogue.charactersInfo[message.charId].name;
            DialogueText.text = message.text;
            position++;
        }else{
            this.gameObject.SetActive(false);
        }
    }
}
