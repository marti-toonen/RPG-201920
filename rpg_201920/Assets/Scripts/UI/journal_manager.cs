using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class journal_manager : MonoBehaviour
{
    public Text journal_text;

    public Animator animator;

    private List<string> journal_entries;

    void Start() {
        journal_entries = new List<string>();
    }

    public void add_journal(base_journal journal) {
        foreach(string journal_entry in journal.journal_entry) {
            if(!journal_entries.Contains(journal_entry))
                journal_entries.Add(journal_entry);
        }
        StartCoroutine(toggle_update());
        journal_text.text += journal_entries.Last() + "\n\n";
    }

    IEnumerator toggle_update() {
        animator.SetBool("journal_added", true);

        yield return new WaitForSeconds(3);

        animator.SetBool("journal_added", false);
    }
}
