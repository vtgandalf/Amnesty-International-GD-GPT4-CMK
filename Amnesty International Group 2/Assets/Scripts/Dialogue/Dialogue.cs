using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : ScriptableObject
{
    public CharacterInfo[] charactersInfo;
    public Message[] messages;
    public Note note;
}
