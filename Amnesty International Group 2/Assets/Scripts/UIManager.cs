using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject journalBox;
    public GameObject menuButton;
    public GameObject journalButton;

    public void OpenJournal()
    {
        journalBox.SetActive(true);
        journalButton.SetActive(false);
        menuButton.SetActive(false);
    }

    public void CloseJournal()
    {
        journalBox.SetActive(false);
        journalButton.SetActive(true);
        menuButton.SetActive(true);
    }
}
