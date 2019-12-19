using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class stat_creation : character_stats
{
    public GameObject stat_screen;

    public void OnClicked(Button button) {
        switch(button.name) {
            case "Diplomat":
                GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value = 5;
                GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value = 3;
                GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value = 3;
                stat_screen.SetActive(false);
                break;
            case "Iron Fist":
                GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value = 3;
                GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value = 5;
                GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value = 3;
                stat_screen.SetActive(false);
                break;
            case "Nancy Drew":
                GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value = 3;
                GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value = 3;
                GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value = 5;
                stat_screen.SetActive(false);
                break;
            default:
                Debug.Log("Well, It Didn't Work.");
                break;
        }
    }
}
