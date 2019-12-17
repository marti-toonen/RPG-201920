using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class journal_manager : MonoBehaviour
{
    public Text journal_text;

    private Queue<string> journal_entries;

    public void add_journal(base_journal journal) {
        foreach(string entry in journal_entries) {
            journal_entries.Enqueue(entry);
        }

        string journal_entry = journal_entries.Dequeue();
        journal_text.text = journal_entry;
    }
}
