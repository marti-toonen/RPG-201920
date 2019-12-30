using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class journal_manager : MonoBehaviour
{
    public Text journal_text;

    private List<string> journal_entries;

    public void add_journal(base_journal journal) {
        journal_entries.Add(journal.journal_entry.ToString());

        for(int i = 0; i < journal_entries.Count; i++) {
            journal_text.text = journal_entries[i] + "\n";
        }
    }
}
