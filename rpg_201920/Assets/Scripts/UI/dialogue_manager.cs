using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_manager : MonoBehaviour
{
    private GameObject deputy_bubble;
    private GameObject young_bubble;
    private GameObject widow_bubble;
    public GameObject snake_bubble;

    public GameObject deputy_highway_bubble;
    public GameObject young_highway_bubble;

    private Player player;

    public Text name_text;
    public Text dialogue_text;

    public Button persuade_button;
    public Button intimidate_button;
    public Button investigate_button;

    public Button continue_button;

    public Animator animator_textbox;
    public Animator animator_choicebox;

    public Queue<string> sentences;

    public bool can_manipulate_highway = false;

    private int player_persuasion;
    private int player_intimidation;
    private int player_intuition;

    void Start() {
        sentences = new Queue<string>();

        deputy_bubble = GameObject.Find("information_deputy01");
        young_bubble = GameObject.Find("information_young01");

        player = FindObjectOfType<Player>();
    }

    void Update() {
        player_persuasion = GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value;
        player_intimidation = GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value;
        player_intuition = GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value;

        widow_bubble = GameObject.Find("information_widow01");
    }

    public void start_dialogue(dialogue_class dialogue) {
        if(!animator_textbox.GetBool("textbox_open")) {
            animator_textbox.SetBool("textbox_open", true);
            player.can_move = false;
        }

        if(dialogue.dialogue_options.Length != 0) {
            persuade_button.GetComponentInChildren<Text>().text = dialogue.dialogue_options[0];
            intimidate_button.GetComponentInChildren<Text>().text = dialogue.dialogue_options[1];
            investigate_button.GetComponentInChildren<Text>().text = dialogue.dialogue_options[2];
        }

        name_text.text = dialogue.npc_name;

        switch(dialogue.npc_name) {
            case "Deputy":
                if(deputy_bubble.activeSelf)
                    deputy_bubble.SetActive(false);
                else if(deputy_highway_bubble.activeSelf && !young_bubble.activeSelf) {
                    deputy_highway_bubble.SetActive(false);
                    young_highway_bubble.SetActive(true);
                }
                break;
            case "Young Gun":
                if(young_bubble.activeSelf)
                    young_bubble.SetActive(false);


                else if(young_highway_bubble.activeSelf) {
                    if(player_persuasion == 5)
                        GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value += 3;
                    else if(player_intimidation == 5)
                        GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value += 3;
                    else if(player_intuition == 5)
                        GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value += 3;
                    else
                        Debug.Log("Oh Ariana, we're really in it now.");

                    young_highway_bubble.SetActive(false);
                }
                break;
            case "The Highwayman":
                int highwayman_persuasion = GameObject.Find("Highwayman").GetComponent<character_stats>().persuasion.base_value;
                int highwayman_intimidation = GameObject.Find("Highwayman").GetComponent<character_stats>().intimidation.base_value;
                int highwayman_intuition = GameObject.Find("Highwayman").GetComponent<character_stats>().intuition.base_value;

                if(player_persuasion > highwayman_persuasion || player_intimidation > highwayman_intimidation || player_intuition > highwayman_intuition) {
                    GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate = true;
                }
                else {
                    if(!deputy_bubble.activeSelf)
                        deputy_highway_bubble.SetActive(true);
                }
                break;
            case "The Widower":
                if(widow_bubble.activeSelf) {
                    widow_bubble.SetActive(false);
                    snake_bubble.SetActive(true);
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
        if(sentences.Count == 0 && GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate && !GameObject.Find("Highwayman").GetComponent<character_stats>().information_gained) {
            animator_choicebox.SetBool("choicebox_open", true);
            continue_button.interactable = false;
        }
        else if(sentences.Count == 0) {
            animator_textbox.SetBool("textbox_open", false);
            player.can_move = true;
            return;
        }
        else {
            string sentence = sentences.Dequeue();
            dialogue_text.text = sentence;
        }
    }
}
