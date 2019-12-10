using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_trigger : MonoBehaviour
{
    public dialogue_class dialogue;

    void OnMouseDown() {
        FindObjectOfType<dialogue_manager>().start_dialogue(dialogue);
    }
}
