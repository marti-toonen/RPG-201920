using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_choice : MonoBehaviour
{
    public Animator animator_choicebox;
    
    public void dialogue_react(Button button) {
        switch(button.name) {
            case "Persuade":
                animator_choicebox.SetBool("choicebox_open", false);
                Debug.Log("Here We Are.");
                break;
            case "Intimidate":
                animator_choicebox.SetBool("choicebox_open", false);
                Debug.Log("Here We Are.");
                break;
            case "Investigate":
                animator_choicebox.SetBool("choicebox_open", false);
                Debug.Log("Here We Are.");
                break;
            default:
                Debug.Log("Here We Aren't.");
                break;
        }
    }
}
