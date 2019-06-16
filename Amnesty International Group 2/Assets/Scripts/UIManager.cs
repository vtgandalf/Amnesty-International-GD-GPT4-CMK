using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject journalBox;
    public GameObject menuButton;
    public GameObject journalButton;
    public GameObject touchControls;
    public GameObject dpad;
    public SceneEventHandler SceneEventHandler;
    private void Start() {
        SceneEventHandler.ConversationWithNadyaEvent.AddListener(ConversationWithNadyaEventAction);
        SceneEventHandler.ConversationWithFatherEvent.AddListener(ConversationWithFatherEventAction);
    }

    public void OpenJournal()
    {
        journalBox.SetActive(true);
        journalButton.SetActive(false);
        menuButton.SetActive(false);
        touchControls.SetActive(false);
    }

    public void CloseJournal()
    {
        journalBox.SetActive(false);
        journalButton.SetActive(true);
        menuButton.SetActive(true);
        touchControls.SetActive(true);
    }

    private void ConversationWithNadyaEventAction(bool x)
    {
        journalBox.SetActive(false);
        journalButton.SetActive(false);
        menuButton.SetActive(false);
        touchControls.SetActive(false);
    }

    private void ConversationWithFatherEventAction(bool x)
    {
        journalButton.SetActive(true);
        dpad.SetActive(true);
    }
}
