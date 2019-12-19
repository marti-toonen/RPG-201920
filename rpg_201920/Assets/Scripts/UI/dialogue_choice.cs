using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_choice : MonoBehaviour
{
    public Animator animator_choicebox;
    public dialogue_class dialogue;

    public Button continue_button;
    public Text dialogue_text;

    void dialogue_react(Button button) {
        switch(button.name) {
            case "Persuade":
                animator_choicebox.SetBool("choicebox_open", false);

                if(dialogue.npc_name == "The Highwayman") {
                    FindObjectOfType<dialogue_manager>().start_dialogue(dialogue);
                }

                GameObject.Find("dialogue_manager").GetComponent<dialogue_manager>().can_manipulate = false;
                continue_button.interactable = true;
                break;
            case "Intimidate":
                animator_choicebox.SetBool("choicebox_open", false);
                continue_button.interactable = true;
                Debug.Log("Here We Are.");
                break;
            case "Investigate":
                animator_choicebox.SetBool("choicebox_open", false);
                continue_button.interactable = true;
                Debug.Log("Here We Are.");
                break;
            default:
                Debug.Log("Here We Aren't.");
                break;
        }
    }
}
