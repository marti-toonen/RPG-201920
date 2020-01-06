using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class journal_manager : MonoBehaviour
{
    public Text journal_text;

    private List<string> journal_entries;

    void Start() {
        journal_entries = new List<string>();
    }

    public void add_journal(base_journal journal) {
        foreach(string journal_entry in journal.journal_entry) {
            if(!journal_entries.Contains(journal_entry))
                journal_entries.Add(journal_entry);
        }

        for(int i = 0; i < journal_entries.Count; i++) {
            journal_text.text = journal_entries[0] + "\n\n";
            if(journal_entries.Count > 1)
                journal_text.text += journal_entries[i] + "\n\n";
        }
    }
}
