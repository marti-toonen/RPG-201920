using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float move_speed = 5;

    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") <= 0.5f)
            transform.Translate(new Vector2(Input.GetAxis("Horizontal"), 0f) * move_speed * Time.deltaTime);
        if(Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Vertical") <= 0.5f)
            transform.Translate(new Vector2(0f, Input.GetAxis("Vertical")) * move_speed * Time.deltaTime);
    }
}
