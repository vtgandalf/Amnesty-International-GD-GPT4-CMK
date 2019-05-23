using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI noteName;
    [SerializeField] private TMPro.TextMeshProUGUI noteEntry;
    [SerializeField] private NoteList noteList;

    public bool loop = true;
    private int currentIndex = 0;

    private void Awake()
    {
        if (noteList.Notes.Count <= 0)
            return;

        DisplayCurrentNote();
    }

    private void SetIndexInBounds()
    {
        if (currentIndex > noteList.Notes.Count - 1)
            currentIndex = noteList.Notes.Count - 1;
        else if (currentIndex < 0)
            currentIndex = 0;
    }

    private void DisplayCurrentNote()
    {
        SetIndexInBounds();

        Note currentNote = noteList.Notes[currentIndex];
        noteName.text = currentNote.Name;
        noteEntry.text = currentNote.Entry;
    }

    public void NextNote()
    {
        if (noteList.Notes.Count <= 0)
            return;

        currentIndex++;
        if (loop && currentIndex > noteList.Notes.Count - 1)
            currentIndex = 0;

        DisplayCurrentNote();
    }

    public void PreviousNote()
    {
        if (noteList.Notes.Count <= 0)
            return;

        currentIndex--;
        if (loop && currentIndex < 0)
            currentIndex = noteList.Notes.Count - 1;

        DisplayCurrentNote();
    }
}
