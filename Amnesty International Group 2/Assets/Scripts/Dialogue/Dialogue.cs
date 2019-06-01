using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Dialogue", menuName ="Dialogue/New Dialogue")]
public class Dialogue : ScriptableObject
{
    public CharacterInfo[] charactersInfo;
    public Message[] messages;
    public JournalEntry[] notes;
}
