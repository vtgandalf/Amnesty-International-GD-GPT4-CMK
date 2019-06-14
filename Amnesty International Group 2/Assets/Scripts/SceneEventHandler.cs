using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scene1Event: UnityEvent<bool>{}
public class Scene2Event: UnityEvent<bool>{}
public class Scene2DoorKnock: UnityEvent<bool>{}
public class ConversationWithFatherEvent: UnityEvent<bool>{}
public class ConversationWithNeighbour1Event: UnityEvent<bool>{}
public class ConversationWithSalesmanEvent: UnityEvent<bool>{}
public class ConversationWithBeggarEvent: UnityEvent<bool>{}
public class ConversationWithNeighbour2Event: UnityEvent<bool>{}
public class ConversationWithTeacherEvent: UnityEvent<bool>{}

[CreateAssetMenu(fileName = "SceneEC", menuName = "EventCallers/Scene")]
public class SceneEventHandler : ScriptableObject
{
    public Scene1Event Scene1Event = new Scene1Event();
    public Scene2Event Scene2Event = new Scene2Event();
    public Scene2DoorKnock Scene2DoorKnock = new Scene2DoorKnock();
    public ConversationWithFatherEvent ConversationWithFatherEvent = new ConversationWithFatherEvent();
    public ConversationWithNeighbour1Event ConversationWithNeighbour1Event = new ConversationWithNeighbour1Event();
    public ConversationWithSalesmanEvent ConversationWithSalesmanEvent = new ConversationWithSalesmanEvent();
    public ConversationWithBeggarEvent ConversationWithBeggarEvent = new ConversationWithBeggarEvent();
    public ConversationWithNeighbour2Event ConversationWithNeighbour2Event = new ConversationWithNeighbour2Event();
    public ConversationWithTeacherEvent ConversationWithTeacherEvent = new ConversationWithTeacherEvent();
}
