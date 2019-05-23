using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Might use another class for UI due to changes in Journal
public class NoteDisplay : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI noteName;
    [SerializeField] private TMPro.TextMeshProUGUI noteEntry;
    [SerializeField] private JournalData journal;

    public bool loop = true;
    private int currentIndex = 0;

    private void Awake()
    {
        if (journal.Entries.Count <= 0)
            return;

        DisplayCurrentNote();
    }

    private void SetIndexInBounds()
    {
        if (currentIndex > journal.Entries.Count - 1)
            currentIndex = journal.Entries.Count - 1;
        else if (currentIndex < 0)
            currentIndex = 0;
    }

    private void DisplayCurrentNote()
    {
        SetIndexInBounds();

        JournalEntry currentNote = journal.Entries[currentIndex];
        noteName.text = currentNote.Name;
        noteEntry.text = currentNote.Entry;
    }

    public void NextNote()
    {
        if (journal.Entries.Count <= 0)
            return;

        currentIndex++;
        if (loop && currentIndex > journal.Entries.Count - 1)
            currentIndex = 0;

        DisplayCurrentNote();
    }

    public void PreviousNote()
    {
        if (journal.Entries.Count <= 0)
            return;

        currentIndex--;
        if (loop && currentIndex < 0)
            currentIndex = journal.Entries.Count - 1;

        DisplayCurrentNote();
    }
}
