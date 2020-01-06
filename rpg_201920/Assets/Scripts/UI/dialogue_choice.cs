using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_choice : MonoBehaviour
{
    public Animator animator_choicebox;

    public dialogue_class failure_dialogue;
    public dialogue_class success_dialogue;

    public Button continue_button;

    private GameObject highway_bubble;
    public GameObject widow_button;

    void Start() {
        highway_bubble = GameObject.Find("information_highway01");
    }

    void dialogue_react(Button button) {
        switch(button.name) {
            case "Persuade":
                if(GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate) {
                    FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);
                    GameObject.Find("Highwayman").GetComponent<character_stats>().information_gained = true;
                    widow_button.SetActive(true);
                    GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value += 1;
                }
                else {
                    FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);
                }

                if(highway_bubble.activeSelf)
                    highway_bubble.SetActive(false);

                continue_button.interactable = true;
                animator_choicebox.SetBool("choicebox_open", false);
                break;
            case "Intimidate":
                if(GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate) {
                    FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);
                    GameObject.Find("Highwayman").GetComponent<character_stats>().information_gained = true;
                    widow_button.SetActive(true);
                    GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value += 1;
                }

                else {
                    FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);
                }

                if(highway_bubble.activeSelf)
                    highway_bubble.SetActive(false);

                continue_button.interactable = true;
                animator_choicebox.SetBool("choicebox_open", false);
                break;
            case "Investigate":
                if(GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate) {
                    FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);
                    GameObject.Find("Highwayman").GetComponent<character_stats>().information_gained = true;
                    widow_button.SetActive(true);
                    GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value += 1;
                }

                else {
                    FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);
                }

                if(highway_bubble.activeSelf)
                    highway_bubble.SetActive(false);

                continue_button.interactable = true;
                animator_choicebox.SetBool("choicebox_open", false);
                break;
            default:
                Debug.Log("Here We Aren't.");
                break;
        }
    }
}
