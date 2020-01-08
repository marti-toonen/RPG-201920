using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue_choice : MonoBehaviour
{
    public Animator animator_choicebox;

    public dialogue_class failure_dialogue;
    public dialogue_class success_dialogue;

    public journal_trigger snake_trigger;

    public Button continue_button;

    private GameObject highway_bubble;

    public GameObject snake_bubble;
    public GameObject widow_button;

    private Player player;

    private int player_persuasion;
    private int player_intimidation;
    private int player_intuition;

    private int highwayman_persuasion;
    private int highwayman_intimidation;
    private int highwayman_intuition;

    private int snake_persuasion;
    private int snake_intimidation;
    private int snake_intuition;

    void Start() {
        player = FindObjectOfType<Player>();
        highway_bubble = GameObject.Find("information_highway01");

        highwayman_persuasion = GameObject.Find("Highwayman").GetComponent<character_stats>().persuasion.base_value;
        highwayman_intimidation = GameObject.Find("Highwayman").GetComponent<character_stats>().intimidation.base_value;
        highwayman_intuition = GameObject.Find("Highwayman").GetComponent<character_stats>().intuition.base_value;

        snake_persuasion = GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().persuasion.base_value;
        snake_intimidation = GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().intimidation.base_value;
        snake_intuition = GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().intuition.base_value;
    }

    void Update() {
        player_persuasion = GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value;
        player_intimidation = GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value;
        player_intuition = GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value;

        if(snake_bubble.activeSelf)
            snake_trigger = GameObject.Find("information_snake01").GetComponent<journal_trigger>();
    }

    void dialogue_react(Button button) {
        switch(button.name) {
            case "Persuade":
                if(GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate) {
                    if(player_persuasion > highwayman_persuasion) {
                        success_dialogue.npc_name = "The Highwayman";
                        success_dialogue.sentences = new string[5];
                        success_dialogue.sentences[0] = "H'mm... all right Sheriff.";
                        success_dialogue.sentences[1] = "Didn't wanna say anything as I have pity for her situation...";
                        success_dialogue.sentences[2] = "...but not enough to get hanged for her.";
                        success_dialogue.sentences[3] = "Just before he was killed, The Banker foreclosed on The Widower's farm.";
                        success_dialogue.sentences[4] = "You oughta speak to her, to the southeast.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);

                        GameObject.Find("Highwayman").GetComponent<character_stats>().information_gained = true;
                        widow_button.SetActive(true);

                        GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value += 1;
                        GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate = false;

                        if(highway_bubble.activeSelf)
                            highway_bubble.SetActive(false);
                    }
                    else {
                        failure_dialogue.npc_name = "The Highwayman";
                        failure_dialogue.sentences = new string[1];
                        failure_dialogue.sentences[0] = "Nice try, Sheriff.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);

                        highway_bubble.SetActive(true);
                    }
                }
                else if(GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().can_manipulate) {
                    if(player_persuasion > snake_persuasion) {
                        success_dialogue.npc_name = "The Snakeoil Salesman";
                        success_dialogue.sentences = new string[5];
                        success_dialogue.sentences[0] = "Where'd you get that!?";
                        success_dialogue.sentences[1] = "Doesn't matter, doesn't matter...";
                        success_dialogue.sentences[2] = "You're a reasonable person, Sheriff, I'm sure.";
                        success_dialogue.sentences[3] = "The Banker was only taking a little laudanum!";
                        success_dialogue.sentences[4] = "Surely that doesn't account for the wounds that The Young Blood saw.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);

                        GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().information_gained = true;

                        GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value += 1;
                        GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().can_manipulate = false;

                        snake_trigger.write_journal("information_snake01");

                        if(snake_bubble.activeSelf)
                            snake_bubble.SetActive(false);
                    }
                    else {
                        failure_dialogue.npc_name = "The Snakeoil Salesman";
                        failure_dialogue.sentences = new string[1];
                        failure_dialogue.sentences[0] = "Slander! Well I never! I'm being attacked by the medical community!.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);

                        snake_bubble.SetActive(true);
                    }
                }

                continue_button.interactable = true;
                animator_choicebox.SetBool("choicebox_open", false);
                break;
            case "Intimidate":
                if(GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate) {
                    if(player_intimidation > highwayman_intimidation) {
                        success_dialogue.npc_name = "The Highwayman";
                        success_dialogue.sentences = new string[5];
                        success_dialogue.sentences[0] = "All right, settle down Sheriff!";
                        success_dialogue.sentences[1] = "Now I was gunna keep this to myself...";
                        success_dialogue.sentences[2] = "...but I won't hang for pity.";
                        success_dialogue.sentences[3] = "Just before he was killed, The Banker foreclosed on The Widower's farm.";
                        success_dialogue.sentences[4] = "You oughta speak to her, to the southeast.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);

                        GameObject.Find("Highwayman").GetComponent<character_stats>().information_gained = true;
                        widow_button.SetActive(true);

                        GameObject.Find("Player").GetComponent<character_stats>().intimidation.base_value += 1;
                        GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate = false;

                        if(highway_bubble.activeSelf)
                            highway_bubble.SetActive(false);
                    }
                    else {
                        failure_dialogue.npc_name = "The Highwayman";
                        failure_dialogue.sentences = new string[1];
                        failure_dialogue.sentences[0] = "Nice try, Sheriff.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);

                        highway_bubble.SetActive(true);
                    }
                }
                else if(GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().can_manipulate) {
                    if(player_intimidation > snake_intimidation) {
                        success_dialogue.npc_name = "The Snakeoil Salesman";
                        success_dialogue.sentences = new string[5];
                        success_dialogue.sentences[0] = "N-Now hang on just a minute! What have you got there...";
                        success_dialogue.sentences[1] = "Aw shoot.";
                        success_dialogue.sentences[2] = "S-Sheriff, you seem like the reasonable sort.";
                        success_dialogue.sentences[3] = "The Banker was only taking a little laudanum!";
                        success_dialogue.sentences[4] = "Surely that doesn't account for the wounds that The Young Gun saw.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);

                        GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().information_gained = true;

                        GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value += 1;
                        GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().can_manipulate = false;

                        snake_trigger.write_journal("information_snake01");

                        if(snake_bubble.activeSelf)
                            snake_bubble.SetActive(false);
                    }
                    else {
                        failure_dialogue.npc_name = "The Snakeoil Salesman";
                        failure_dialogue.sentences = new string[1];
                        failure_dialogue.sentences[0] = "Slander! Well I never! I'm being attacked by the medical community!.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);

                        snake_bubble.SetActive(true);
                    }
                }

                continue_button.interactable = true;
                animator_choicebox.SetBool("choicebox_open", false);
                break;
            case "Investigate":
                if(GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate) {
                    if(player_intuition > highwayman_intuition) {
                        success_dialogue.npc_name = "The Highwayman";
                        success_dialogue.sentences = new string[5];
                        success_dialogue.sentences[0] = "I wouldn't go that far, but something is weighing on my mind.";
                        success_dialogue.sentences[1] = "Now I was keeping this to myself out of pity...";
                        success_dialogue.sentences[2] = "...but I won't hang for pity.";
                        success_dialogue.sentences[3] = "Just before he was killed, The Banker foreclosed on The Widower's farm.";
                        success_dialogue.sentences[4] = "You oughta speak to her, to the southeast.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);

                        GameObject.Find("Highwayman").GetComponent<character_stats>().information_gained = true;
                        widow_button.SetActive(true);

                        GameObject.Find("Player").GetComponent<character_stats>().intuition.base_value += 1;
                        GameObject.Find("Highwayman").GetComponent<character_stats>().can_manipulate = false;

                        if(highway_bubble.activeSelf)
                            highway_bubble.SetActive(false);
                    }
                    else {
                        failure_dialogue.npc_name = "The Highwayman";
                        failure_dialogue.sentences = new string[1];
                        failure_dialogue.sentences[0] = "Nice try, Sheriff.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);

                        highway_bubble.SetActive(true);
                    }
                }
                else if(GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().can_manipulate) {
                    if(player_intuition > snake_intuition) {
                        success_dialogue.npc_name = "The Snakeoil Salesman";
                        success_dialogue.sentences = new string[5];
                        success_dialogue.sentences[0] = "You've got w-what?";
                        success_dialogue.sentences[1] = "Aw shoot. I hate medical evidence.";
                        success_dialogue.sentences[2] = "S-Sheriff, you seem like the reasonable sort.";
                        success_dialogue.sentences[3] = "The Banker was only taking a little laudanum!";
                        success_dialogue.sentences[4] = "Surely that doesn't account for the wounds that The Young Gun saw.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(success_dialogue);

                        GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().information_gained = true;

                        GameObject.Find("Player").GetComponent<character_stats>().persuasion.base_value += 1;
                        GameObject.Find("Snakeoil Salesman").GetComponent<character_stats>().can_manipulate = false;

                        snake_trigger.write_journal("information_snake01");

                        if(snake_bubble.activeSelf)
                            snake_bubble.SetActive(false);
                    }
                    else {
                        failure_dialogue.npc_name = "The Snakeoil Salesman";
                        failure_dialogue.sentences = new string[1];
                        failure_dialogue.sentences[0] = "Slander! Well I never! I'm being attacked by the medical community!.";
                        FindObjectOfType<dialogue_manager>().start_dialogue(failure_dialogue);

                        snake_bubble.SetActive(true);
                    }
                }

                continue_button.interactable = true;
                animator_choicebox.SetBool("choicebox_open", false);
                break;
            default:
                Debug.Log("Here We Aren't.");
                break;
        }
    }
}
