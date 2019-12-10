using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle_menu : MonoBehaviour
{
    private bool journal_open = false;

    public Button journal_button;

    public GameObject journal_menu;

    public void toggle_journal() {
        if(!journal_open) {
            journal_menu.SetActive(true);
            journal_open = true;
        }
        else {
            journal_menu.SetActive(false);
            journal_open = false;
        }
    }
}
