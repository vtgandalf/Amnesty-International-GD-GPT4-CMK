using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue LoadDialogue(){
        return this.dialogue;
    }

    public Message LoadText(int x){
        return this.dialogue.messages[x];
    }
}
