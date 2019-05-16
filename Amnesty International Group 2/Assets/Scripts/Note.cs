using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Note
{
    public string Name;
    public string Entry;

    public Note(string name, string entry)
    {
        Name = name;
        Entry = entry;
    }
}
