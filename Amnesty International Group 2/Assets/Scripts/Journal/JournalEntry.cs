using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JournalEntryType
{
    STORY,
    OBJECTIVE,
    NOTE
}

[System.Serializable]
[CreateAssetMenu(fileName = "JournalEntry", menuName = "Journal/Entry")]
public class JournalEntry
{
    public string Name; // Name only used for stories
    public string Entry;
    public JournalEntryType JEType;

    public JournalEntry(string name, string entry, JournalEntryType type) : this(entry, type)
    {
        Name = name;
    }

    public JournalEntry(string entry, JournalEntryType type) 
    {
        Entry = entry;
        JEType = type;
    }
}
