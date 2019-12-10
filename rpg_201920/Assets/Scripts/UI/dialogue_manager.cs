using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_manager : MonoBehaviour
{
    private Queue<string> sentences;

    void Start() {
        sentences = new Queue<string>();
    }

    public void start_dialogue(dialogue_class dialogue) {
        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        display_next();
    }

    public void display_next() {
        if(sentences.Count == 0) {
            end_dialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    void end_dialogue() {
        Debug.Log("Done Talking");
    }
}
