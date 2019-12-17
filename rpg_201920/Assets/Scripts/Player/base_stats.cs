using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class base_stats
{
    [SerializeField]
    public int base_value;

    public int get_value() {
        return base_value;
    }
}
