using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float move_speed = 7;

    private Animator animator;
    private Rigidbody2D player_rigidbody;

    private Vector2 move_input;

    void Start() {
        animator = GetComponent<Animator>();
        player_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move_input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if(move_input != Vector2.zero)
            player_rigidbody.velocity = new Vector2(move_input.x * move_speed, move_input.y * move_speed);
        else
            player_rigidbody.velocity = Vector2.zero;

        animator.SetFloat("move_x", Input.GetAxis("Horizontal"));
        animator.SetFloat("move_y", Input.GetAxis("Vertical"));
    }
}
