using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ReportEvaluation", menuName = "Report/Evaluation")]
public class ReportEvaluation : ScriptableObject
{
    public List<JournalEntry> stories = new List<JournalEntry>();
    private float grade = 0f;

    private void OnEnable() {
        stories = new List<JournalEntry>();
    }
    public void AddStory(JournalEntry entry)
    {
        if (!stories.Contains(entry))
        {
            stories.Add(entry);
            UpdateGrade();
        }
    }

    private void UpdateGrade()
    {
        int weights = 0;
        foreach (JournalEntry x in stories)
        {
            weights += (int)x.Weight;
        }
        grade = (weights / stories.Count)/(float)(int)StoryWeight.MAX;
        Debug.Log("grade: "+ grade);
    }

    public float Grade { get { return this.grade; } }
}
