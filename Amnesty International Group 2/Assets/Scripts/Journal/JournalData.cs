using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName = "JournalData", menuName = "Journal/EntryList")]
public class JournalData : ScriptableObject
{
    public List<JournalEntry> Entries = new List<JournalEntry>();
    private List<JournalEntry> stories = new List<JournalEntry>();
    private List<JournalEntry> objectves = new List<JournalEntry>();
    private List<JournalEntry> notes = new List<JournalEntry>();

    private void OnEnable() {
        Entries = new List<JournalEntry>();
        stories = new List<JournalEntry>();
        objectves = new List<JournalEntry>();
        notes = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        if (!Entries.Contains(entry))
        {
            Entries.Add(entry);
            OrderList(Entries);
        }
        switch (entry.JEType)
        {
            case JournalEntryType.STORY:
                if (!stories.Contains(entry))
                {
                    stories.Add(entry);
                    OrderList(stories);
                }
                break;

            case JournalEntryType.OBJECTIVE:
                if (!objectves.Contains(entry))
                {
                    objectves.Add(entry);
                    OrderList(objectves);
                }
                break;

            case JournalEntryType.NOTE:
                if (!notes.Contains(entry))
                {
                    notes.Add(entry);
                    OrderList(notes);
                }
                break;

            default:
                break;
        }
    }

    public void RemoveEntry(JournalEntry entry)
    {
        if (Entries.Contains(entry))
        {
            Entries.Remove(entry);
        }
    }

    private void OrderList(List<JournalEntry> x)
    {
        x.Sort((a, b) => a.JEType.CompareTo(b.JEType));
    }

    public List<JournalEntry> Stories { get { return stories; } }
    public List<JournalEntry> Objectves { get { return objectves; } }
    public List<JournalEntry> Notes { get { return notes; } }
    public void UpdateLists()
    {
        stories = new List<JournalEntry>();
        objectves = new List<JournalEntry>();
        notes = new List<JournalEntry>();

        foreach (JournalEntry x in Entries)
        {
            AddEntry(x);
        }
    }
}
