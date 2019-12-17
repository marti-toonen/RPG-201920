using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class journal_trigger : MonoBehaviour
{
    public base_journal journal;

    void OnMouseDown() {
        FindObjectOfType<journal_manager>().add_journal(journal);
    }
}
