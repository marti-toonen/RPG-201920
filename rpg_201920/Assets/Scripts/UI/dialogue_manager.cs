using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_manager : MonoBehaviour
{
    private GameObject deputy_bubble;
    private GameObject young_bubble;

    public GameObject player;
    public GameObject opponent;

    public Text name_text;
    public Text dialogue_text;

    public Button persuade_button;
    public Button intimidate_button;
    public Button investigate_button;

    public Button continue_button;

    public Animator animator_textbox;
    public Animator animator_choicebox;

    private Queue<string> sentences;

    private bool highwayman_quiet = false;

    void Start() {
        sentences = new Queue<string>();

        deputy_bubble = GameObject.Find("exclamation_deputy");
        young_bubble = GameObject.Find("frustrated_young");
    }

    public void start_dialogue(dialogue_class dialogue) {
        animator_textbox.SetBool("textbox_open", true);

        if(dialogue.persuade_text != null) {
            persuade_button.GetComponentInChildren<Text>().text = dialogue.persuade_text;
            intimidate_button.GetComponentInChildren<Text>().text = dialogue.intimidate_text;
            investigate_button.GetComponentInChildren<Text>().text = dialogue.investigate_text;
        }

        name_text.text = dialogue.npc_name;

        switch(dialogue.npc_name) {
            case "Deputy":
                deputy_bubble.SetActive(false);
                break;
            case "Young Gun":
                young_bubble.SetActive(false);
                break;
            case "The Highwayman":
                highwayman_quiet = true;
                break;
            default:
                break;
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        display_next();
    }

    public void display_next() {
        if(sentences.Count == 1 && highwayman_quiet) {
            animator_choicebox.SetBool("choicebox_open", true);
            continue_button.interactable = false;
        }
        else if(sentences.Count == 0) {
            animator_textbox.SetBool("textbox_open", false);
            return;
        }
        string sentence = sentences.Dequeue();
        dialogue_text.text = sentence;
    }
}
