using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NoteList : ScriptableObject
{
    public List<Note> Notes = new List<Note>();
}
