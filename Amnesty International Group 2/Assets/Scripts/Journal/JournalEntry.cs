using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum JournalEntryType
{
    STORY,
    OBJECTIVE,
    NOTE
}

public enum StoryWeight
{
    NOTRELEVANT,
    MIN,
    MID,
    MAX
}

[System.Serializable]
[CreateAssetMenu(fileName = "JournalEntry", menuName = "Journal/Entry")]
public class JournalEntry
{
    public string Name; // Name only used for stories
    public string Entry;
    public JournalEntryType JEType;
    public StoryWeight Weight;

    public JournalEntry(string name, string entry, JournalEntryType type, StoryWeight weight) : this(entry, type, weight)
    {
        Name = name;
    }

    public JournalEntry(string entry, JournalEntryType type, StoryWeight weight) 
    {
        Entry = entry;
        JEType = type;
        if(type == JournalEntryType.STORY)
        {
            Weight = weight;
        }
    }
}