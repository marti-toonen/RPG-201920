using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_manager : MonoBehaviour
{
    private GameObject deputy_bubble;
    private GameObject young_bubble;
    private GameObject highway_bubble;

    public GameObject deputy_highway_bubble;
    public GameObject young_highway_bubble;

    public Text name_text;
    public Text dialogue_text;

    public Button persuade_button;
    public Button intimidate_button;
    public Button investigate_button;

    public Button continue_button;

    public Animator animator_textbox;
    public Animator animator_choicebox;

    public Queue<string> sentences;

    public bool can_manipulate = false;

    public int player_persuasion;
    public int player_intimidation;
    public int player_intuition;

    void Start() {
        sentences = new Queue<string>();

        deputy_bubble = GameObject.Find("exclamation_deputy");
        young_bubble = GameObject.Find("frustrated_young");
        highway_bubble = GameObject.Find("hesitant_outlaw");
    }

    void Update() {
        player_persuasion = GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value;
        player_intimidation = GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value;
        player_intuition = GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value;

        // young gun

        if(!young_bubble.activeSelf && !deputy_highway_bubble.activeSelf)
            young_highway_bubble.SetActive(true);

        // deputy

        if(deputy_highway_bubble.activeSelf) {
            deputy_highway_bubble.SetActive(false);
            if(!young_bubble.activeSelf)
                young_highway_bubble.SetActive(true);
        }
    }

    public void start_dialogue(dialogue_class dialogue) {
        if(!animator_textbox.GetBool("textbox_open"))
            animator_textbox.SetBool("textbox_open", true);

        if(dialogue.dialogue_options.Length != 0) {
            persuade_button.GetComponentInChildren<Text>().text = dialogue.dialogue_options[0];
            intimidate_button.GetComponentInChildren<Text>().text = dialogue.dialogue_options[1];
            investigate_button.GetComponentInChildren<Text>().text = dialogue.dialogue_options[2];
        }

        name_text.text = dialogue.npc_name;

        switch(dialogue.npc_name) {
            case "Deputy":
                deputy_bubble.SetActive(false);
                break;
            case "Young Gun":
                young_bubble.SetActive(false);
                if(young_highway_bubble.activeSelf) {
                    if(player_persuasion > player_intimidation && player_persuasion > player_intuition)
                        GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value += 3;
                    else if(player_intimidation > player_persuasion && player_intimidation > player_intuition)
                        GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value += 3;
                    else if(player_intuition > player_persuasion && player_intuition > player_intimidation)
                        GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value += 3;
                    else
                        Debug.Log("Oh Ariana, we're really in it now.");

                    young_highway_bubble.SetActive(false);
                }
                break;
            case "The Highwayman":
                int highwayman_persuasion = GameObject.Find("Highwayman").GetComponent<character_stats>().persuasion.base_value;
                if(player_persuasion > highwayman_persuasion) {
                    can_manipulate = true;
                    highway_bubble.SetActive(false);
                }
                else {
                    if(!deputy_bubble.activeSelf)
                        deputy_highway_bubble.SetActive(true);
                }
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
        if(sentences.Count == 0 && can_manipulate) {
            animator_choicebox.SetBool("choicebox_open", true);
            continue_button.interactable = false;
        }
        else if(sentences.Count == 0) {
            animator_textbox.SetBool("textbox_open", false);
            return;
        }
        else {
            string sentence = sentences.Dequeue();
            dialogue_text.text = sentence;
        }
    }
}
