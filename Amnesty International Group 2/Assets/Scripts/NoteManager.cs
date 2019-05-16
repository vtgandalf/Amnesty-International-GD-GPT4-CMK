using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NoteManager : ScriptableObject
{
    public List<Note> Notes = new List<Note>();
}
