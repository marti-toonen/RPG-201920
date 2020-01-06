using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float move_speed = 7;

    public bool can_move;

    private Animator animator;
    private Rigidbody2D player_rigidbody;

    private Vector2 move_input;
    private Vector2 last_direction;

    void Start() {
        animator = GetComponent<Animator>();
        player_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move_input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        animator.SetBool("is_moving", false);

        if(!can_move) {
            player_rigidbody.velocity = Vector2.zero;
            return;
        }

        if(move_input != Vector2.zero) {
            player_rigidbody.velocity = new Vector2(move_input.x * move_speed, move_input.y * move_speed);
            animator.SetBool("is_moving", true);
            if(move_input.x != 0)
                last_direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            else if(move_input.y != 0)
                last_direction = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        else {
            player_rigidbody.velocity = Vector2.zero;
        }

        animator.SetFloat("move_x", Input.GetAxis("Horizontal"));
        animator.SetFloat("move_y", Input.GetAxis("Vertical"));
        animator.SetFloat("last_x", last_direction.x);
        animator.SetFloat("last_y", last_direction.y);
    }
}
