using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class journal_manager : MonoBehaviour
{
    public Text journal_text;

    private Queue<string> journal_entries;

    void Start() {
        journal_entries = new Queue<string>();
    }

    public void add_journal(base_journal journal) {
        foreach(string entry in journal.journal_entry) {
            journal_entries.Enqueue(entry);
        }

        string journal_entry = journal_entries.Dequeue();
        journal_text.text = journal_entry;
    }
}
