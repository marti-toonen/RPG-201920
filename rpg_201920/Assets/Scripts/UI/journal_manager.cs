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
        foreach(string journal_entry in journal.journal_entry) {
            journal_entries.Enqueue(journal_entry);
        }

        for(int i = 0; i < journal_entries.ToArray().Length; i++) {
            string[] entries = journal_entries.ToArray()[i] + "\n";

            journal_text.text = entries.ToString();
        }
    }
}
