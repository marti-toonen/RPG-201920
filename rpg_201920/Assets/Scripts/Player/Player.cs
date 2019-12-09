using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float move_speed = 5;

    private Animator animator;
    private Rigidbody2D player_rigidbody;

    void Start() {
        animator = GetComponent<Animator>();
        player_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") <= 0.5f)
            player_rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * move_speed, player_rigidbody.velocity.y);
        if(Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Vertical") <= 0.5f)
            player_rigidbody.velocity = new Vector2(player_rigidbody.velocity.x, Input.GetAxis("Vertical") * move_speed);

        animator.SetFloat("move_x", Input.GetAxis("Horizontal"));
        animator.SetFloat("move_y", Input.GetAxis("Vertical"));
    }
}
