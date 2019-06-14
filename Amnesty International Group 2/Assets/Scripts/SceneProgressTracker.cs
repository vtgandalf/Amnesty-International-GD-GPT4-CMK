using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneProgressTracker : MonoBehaviour
{
    [SerializeField] private SceneEventHandler SceneEventHandler;
    [SerializeField] private DialogueEventCaller DialogueEventCaller;
    private int scene2DoorKnockCounter = 0;
    public int scene2DoorKnockThreshold = 2;
    public bool hasTalkedWithFather = false;
    public bool scene1Completed = false;
    public bool hasTalkedWithNeighbour1 = false;
    public bool scene2Completed = false;
    public bool doorKnocked = false;
    public Dialogue thoughtAfterFather;
    public Dialogue thoughtAfterScene1;
    public Dialogue thoughtAfterScene2;
    public GameObject journalButton;
    public GameObject scene1TP;
    public GameObject streetToMosqueTP;
    public GameObject streetToSchoolTP;
    public GameObject streetToCampTP;
    public GameObject streetToShopTP;
    public GameObject Father;
    public GameObject Neigbour;
    // Start is called before the first frame update
    void Start()
    {
        SceneEventHandler.Scene1Event.AddListener(Scene1EventAction);
        SceneEventHandler.Scene2Event.AddListener(Scene2EventAction);
        SceneEventHandler.Scene2DoorKnock.AddListener(Scene2DoorKnockEventAction);
        SceneEventHandler.ConversationWithFatherEvent.AddListener(ConversationWithFatherEventAction);
        SceneEventHandler.ConversationWithNeighbour1Event.AddListener(ConversationWithNeighbour1EventAction);
        SceneEventHandler.ConversationWithSalesmanEvent.AddListener(ConversationWithSalesmanEventAction);
        SceneEventHandler.ConversationWithBeggarEvent.AddListener(ConversationWithBeggarEventAction);
        SceneEventHandler.ConversationWithNeighbour2Event.AddListener(ConversationWithNeighbour2EventAction);
        SceneEventHandler.ConversationWithTeacherEvent.AddListener(ConversationWithTeacherEventAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Scene1EventAction(bool x)
    {
        scene1Completed = true;
        DialogueEventCaller.DialogueEvent.Invoke(thoughtAfterScene1);
    }

    private void Scene2EventAction(bool x)
    {
        if(hasTalkedWithNeighbour1)
        {
            scene2Completed = true;
            streetToShopTP.SetActive(true);
            DialogueEventCaller.DialogueEvent.Invoke(thoughtAfterScene2);
        }
    }

    private void Scene2DoorKnockEventAction(bool x)
    {
        Debug.Log("Door Knocked");
        if(!scene2Completed)
        {
            scene2DoorKnockCounter++;
            if(scene2DoorKnockCounter>=scene2DoorKnockThreshold)
            {
                Neigbour.SetActive(true);
                // neighbour comes out
                // dialogue with neighbour
            }
        }
    }

    private void ConversationWithFatherEventAction(bool x)
    {
        hasTalkedWithFather = true;
        scene1TP.SetActive(true);
        journalButton.SetActive(true);
        DialogueEventCaller.DialogueEvent.Invoke(thoughtAfterFather);
        NPCMovementController npcmc = Father.transform.GetComponent<NPCMovementController>();
        npcmc.position = 0;
        npcmc.eventHappened = true;
        npcmc.targetReached = false;
        Object.Destroy(Father, 2f);
    }

    private void ConversationWithNeighbour1EventAction(bool x)
    {
        hasTalkedWithNeighbour1 = true;
        // may be add some thoughs
    }

    private void ConversationWithSalesmanEventAction(bool x)
    {

    }

    private void ConversationWithBeggarEventAction(bool x)
    {

    }

    private void ConversationWithNeighbour2EventAction(bool x)
    {

    }

    private void ConversationWithTeacherEventAction(bool x)
    {

    }


}
