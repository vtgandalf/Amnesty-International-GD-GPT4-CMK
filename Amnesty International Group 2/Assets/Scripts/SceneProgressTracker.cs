using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneProgressTracker : MonoBehaviour
{
    [SerializeField] private SceneEventHandler SceneEventHandler;
    [SerializeField] private DialogueEventCaller DialogueEventCaller;
    private int scene2DoorKnockCounter = 0;
    private int scene5DoorKnockCounter = 0;
    public int scene2DoorKnockThreshold = 2;
    public bool hasTalkedWithFather = false;
    public bool scene1Completed = false;
    public bool doorKnocked = false;
    public bool hasTalkedWithNeighbour1 = false;
    public bool scene2Completed = false;
    public bool hasTalkedWithSalesman = false;
    public bool scene3Completed = false;
    public bool hasTalkedWithBeggar = false;
    public bool scene4Completed = false;
    public bool hasTalkedWithNeighbour2 = false;
    public bool doorKnockedScene5 = false;
    public bool scene5Completed = false;
    public bool hasTalkedWithTeacher = false;
    public bool scene6Completed = false;
    public bool hasTalkedWithNadya = false;
    public bool scene7Completed = false;
    public Dialogue thoughtAfterFather;
    public Dialogue thoughtAfterScene1;
    public Dialogue thoughtAfterScene2;
    public Dialogue thoughtAfterScene3;
    public Dialogue thoughtAfterScene4;

    public Dialogue thoughtAfterScene5;

    public Dialogue thoughtAfterScene6;
    public Dialogue thoughtAfterScene7;


    public GameObject journalButton;
    public GameObject scene1TP;
    public GameObject streetToMosqueTP;
    public GameObject streetToSchoolTP;
    public GameObject streetToCampTP;
    public GameObject streetToShopTP;
    public GameObject Father;
    public GameObject Neighbour1;
    public GameObject Neighbour2;
    public GameObject Nadya;

    // Start is called before the first frame update
    void Start()
    {
        SceneEventHandler.Scene1Event.AddListener(Scene1EventAction);
        SceneEventHandler.Scene2Event.AddListener(Scene2EventAction);
        SceneEventHandler.Scene2DoorKnock.AddListener(Scene2DoorKnockEventAction);
        SceneEventHandler.Scene3Event.AddListener(Scene3EventAction);
        SceneEventHandler.Scene4Event.AddListener(Scene4EventAction);
        SceneEventHandler.Scene5DoorKnock.AddListener(Scene5DoorKnockEventAction);
        SceneEventHandler.Scene5Event.AddListener(Scene5EventAction);
        SceneEventHandler.Scene6Event.AddListener(Scene6EventAction);
        SceneEventHandler.Scene7Event.AddListener(Scene7EventAction);
        SceneEventHandler.ConversationWithFatherEvent.AddListener(ConversationWithFatherEventAction);
        SceneEventHandler.ConversationWithNeighbour1Event.AddListener(ConversationWithNeighbour1EventAction);
        SceneEventHandler.ConversationWithSalesmanEvent.AddListener(ConversationWithSalesmanEventAction);
        SceneEventHandler.ConversationWithBeggarEvent.AddListener(ConversationWithBeggarEventAction);
        SceneEventHandler.ConversationWithNeighbour2Event.AddListener(ConversationWithNeighbour2EventAction);
        SceneEventHandler.ConversationWithTeacherEvent.AddListener(ConversationWithTeacherEventAction);
        SceneEventHandler.ConversationWithNadyaEvent.AddListener(ConversationWithNadyaEventAction);
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
        if (hasTalkedWithNeighbour1)
        {
            scene2Completed = true;
            streetToShopTP.SetActive(true);
            Neighbour1.SetActive(false);
            DialogueEventCaller.DialogueEvent.Invoke(thoughtAfterScene2);
        }
    }

    private void Scene2DoorKnockEventAction(bool x)
    {
        Debug.Log("Door Knocked");
        if (!scene2Completed)
        {
            scene2DoorKnockCounter++;
            if (scene2DoorKnockCounter >= scene2DoorKnockThreshold)
            {
                Neighbour1.SetActive(true);
                // neighbour comes out
                // dialogue with neighbour
            }
        }
    }

    private void Scene3EventAction(bool x)
    {
        if (hasTalkedWithSalesman)
        {
            scene3Completed = true;
            streetToMosqueTP.SetActive(true);
            DialogueEventCaller.DialogueEvent.Invoke(thoughtAfterScene3);
        }
    }

    private void Scene4EventAction(bool x)
    {
        if (hasTalkedWithBeggar)
        {
            scene4Completed = true;
            streetToCampTP.SetActive(true);
            DialogueEventCaller.DialogueEvent.Invoke(thoughtAfterScene4);
        }
    }

    private void Scene5DoorKnockEventAction(bool x)
    {
        if(scene4Completed)
        {
            Debug.Log("Door Knocked Scene 5");
            if (!scene5Completed)
            {
                scene5DoorKnockCounter++;
                if (scene5DoorKnockCounter >= scene2DoorKnockThreshold)
                {
                    Neighbour2.SetActive(true);
                    // neighbour comes out
                    // dialogue with neighbour
                }
            }
        }
    }

    private void Scene5EventAction(bool x)
    {
        if (hasTalkedWithNeighbour2)
        {
            if (!scene5Completed)
            {
                scene5Completed = true;
                streetToSchoolTP.SetActive(true);
                Neighbour2.SetActive(false);
                DialogueEventCaller.DialogueEvent.Invoke(thoughtAfterScene5);
            }
        }
    }

    private void Scene6EventAction(bool x)
    {
        if (hasTalkedWithTeacher)
        {
            scene6Completed = true;
            Nadya.SetActive(true);
            DialogueEventCaller.DialogueEvent.Invoke(thoughtAfterScene6);
        }
    }

    private void Scene7EventAction(bool x)
    {
        if (hasTalkedWithNadya)
        {
            scene7Completed = true;
            DialogueEventCaller.DialogueEvent.Invoke(thoughtAfterScene7);
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
        hasTalkedWithSalesman = true;
    }

    private void ConversationWithBeggarEventAction(bool x)
    {
        hasTalkedWithBeggar = true;
    }

    private void ConversationWithNeighbour2EventAction(bool x)
    {
        hasTalkedWithNeighbour2 = true;
    }

    private void ConversationWithTeacherEventAction(bool x)
    {
        hasTalkedWithTeacher = true;
    }

    private void ConversationWithNadyaEventAction(bool x)
    {
        hasTalkedWithNadya = true;
    }
}
