using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class journal_trigger : MonoBehaviour
{
    public base_journal young_clue;
    public base_journal widow_clue;
    public base_journal snake_clue;

    public void write_journal(string button_name) {
        switch(button_name) {
            case "information_young01":
                young_clue.journal_entry = new string[1];
                young_clue.journal_entry[0] = "The Young Gun heard that The Banker was stabbed.";
                FindObjectOfType<journal_manager>().add_journal(young_clue);
                break;
            case "information_widow01":
                widow_clue.journal_entry = new string[1];
                widow_clue.journal_entry[0] = "Prior to his murder, The Banker foreclosed on The Widower's farm.";
                FindObjectOfType<journal_manager>().add_journal(widow_clue);
                break;
            case "information_snake01":
                if(GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().information_gained) {
                    snake_clue.journal_entry = new string[1];
                    snake_clue.journal_entry[0] = "The Snakeoil Salesman was supplying The Banker with laudanum.";
                    FindObjectOfType<journal_manager>().add_journal(snake_clue);
                }
                break;
            default:
                Debug.Log("Oh Ariana, we're really in it now.");
                break;
        }
    }
}
