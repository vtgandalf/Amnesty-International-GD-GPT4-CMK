using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[CreateAssetMenu(fileName="JournalData", menuName="Journal/EntryList")]
public class JournalData : ScriptableObject
{
    public List<JournalEntry> Entries = new List<JournalEntry>();

    public void AddEntry(JournalEntry entry)
    {
        if (!Entries.Contains(entry))
        {
            Entries.Add(entry);
            OrderList();
        }
    }

    public void RemoveEntry(JournalEntry entry)
    {
        if (Entries.Contains(entry))
        {
            Entries.Remove(entry);
        }
    }

    private void OrderList()
    {
        Entries.Sort((a,b) => a.JEType.CompareTo(b.JEType));
    }
}
