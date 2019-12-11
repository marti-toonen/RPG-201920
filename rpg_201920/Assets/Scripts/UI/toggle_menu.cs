using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle_menu : MonoBehaviour
{
    public Animator animator;

    public void toggle_journal() {
        if(animator.GetBool("journal_open")) {
            animator.SetBool("journal_open", false);
        }
        else {
            animator.SetBool("journal_open", true);
        }
    }
}
