using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle_menu : MonoBehaviour
{
    public Animator animator;

    private Player player;

    void Start() {
        player = FindObjectOfType<Player>();
    }

    public void toggle_journal() {
        if(animator.GetBool("journal_open")) {
            animator.SetBool("journal_open", false);
            player.can_move = true;
        }
        else {
            animator.SetBool("journal_open", true);
            player.can_move = false;
        }
    }
}
