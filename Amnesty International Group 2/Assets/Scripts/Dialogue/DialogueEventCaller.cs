using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueEvent : UnityEvent<Dialogue> { }
public class EmoteEvent : UnityEvent<int> { }

[CreateAssetMenu(fileName="DialogueEC", menuName="EventCallers/Dialogue")]
public class DialogueEventCaller : ScriptableObject
{
    public bool Dialogging;
    public DialogueEvent DialogueEvent = new DialogueEvent();
    public EmoteEvent EmoteEvent = new EmoteEvent();
}
