using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_manager : MonoBehaviour
{
    private GameObject deputy_bubble;
    private GameObject sign01_bubble;

    public Text name_text;
    public Text dialogue_text;

    public Animator animator;

    private Queue<string> sentences;

    void Start() {
        sentences = new Queue<string>();

        deputy_bubble = GameObject.Find("exclamation_deputy");
        sign01_bubble = GameObject.Find("information_sign01");
    }

    public void start_dialogue(dialogue_class dialogue) {
        animator.SetBool("textbox_open", true);
        name_text.text = dialogue.npc_name;

        switch(dialogue.npc_name) {
            case "Deputy":
                deputy_bubble.SetActive(false);
                break;
            case "WELCOME":
                sign01_bubble.SetActive(false);
                break;
            default:
                Debug.Log("You're not supposed to be here!");
                break;
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        display_next();
    }

    public void display_next() {
        if(sentences.Count == 0) {
            animator.SetBool("textbox_open", false);
            return;
        }
        string sentence = sentences.Dequeue();
        dialogue_text.text = sentence;
    }
}
