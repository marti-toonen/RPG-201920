using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class dialogue_class
{
    public string npc_name;

    [TextArea(3, 10)]
    public string[] sentences;

    [TextArea(3, 10)]
    public string persuade_text;
    [TextArea(3, 10)]
    public string intimidate_text;
    [TextArea(3, 10)]
    public string investigate_text;
}
