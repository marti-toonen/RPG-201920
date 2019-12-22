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
    private Text npc_name;
    private GameObject highway_bubble;

    void Start() {
        highway_bubble = GameObject.Find("hesitant_outlaw");
    }

    void dialogue_react(Button button) {
        switch(button.name) {
            case "Persuade":
                if(GameObject.Find("continue_button").GetComponent<dialogue_manager>().can_manipulate_highway == true) {
                    FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);
                    GameObject.Find("dialogue_manager").GetComponent<dialogue_manager>().can_manipulate_highway = false;
                    GameObject.Find("information_widow").SetActive(true);
                }
                else {
                    FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);
                    GameObject.Find("dialogue_manager").GetComponent<dialogue_manager>().can_manipulate_highway = false;
                }

                if(highway_bubble.activeSelf)
                    highway_bubble.SetActive(false);

                continue_button.interactable = true;
                animator_choicebox.SetBool("choicebox_open", false);
                break;
            case "Intimidate":
                animator_choicebox.SetBool("choicebox_open", false);

                if(GameObject.Find("dialogue_manager").GetComponent<dialogue_manager>().can_manipulate_highway) {
                    FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);
                    GameObject.Find("dialogue_manager").GetComponent<dialogue_manager>().can_manipulate_highway = false;
                    GameObject.Find("information_widow").SetActive(true);
                }

                else {
                    FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);
                    GameObject.Find("dialogue_manager").GetComponent<dialogue_manager>().can_manipulate_highway = false;
                }

                if(highway_bubble.activeSelf)
                    highway_bubble.SetActive(false);

                continue_button.interactable = true;
                break;
            case "Investigate":
                animator_choicebox.SetBool("choicebox_open", false);

                if(GameObject.Find("dialogue_manager").GetComponent<dialogue_manager>().can_manipulate_highway) {
                    FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);
                    GameObject.Find("dialogue_manager").GetComponent<dialogue_manager>().can_manipulate_highway = false;
                    GameObject.Find("information_widow").SetActive(true);
                }

                else {
                    FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);
                    GameObject.Find("dialogue_manager").GetComponent<dialogue_manager>().can_manipulate_highway = false;
                }

                if(highway_bubble.activeSelf)
                    highway_bubble.SetActive(false);

                continue_button.interactable = true;
                break;
            default:
                Debug.Log("Here We Aren't.");
                break;
        }
    }
}
