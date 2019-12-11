using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject follow_target;
    private Vector3 target_position;

    private float move_speed = 5;

    private double furthest_left = -17.5;
    private double furthest_right = 35.6;
    private double furthest_top = 17.8;
    private double furthest_bottom = -17.3;

    void Update()
    {
        target_position = new Vector3(follow_target.transform.position.x, follow_target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target_position, move_speed * Time.deltaTime);
    }
}
