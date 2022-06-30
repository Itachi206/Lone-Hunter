using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public Vector3 move_direction;
    public float move_Speed = 4f;
    public float player_Speed = 4f;
    public float gravity = 20f;
    public float jump_Force = 10f;
    public float vertical_Velocity;

    public float sprint_Speed = 8f;
    public float crouch_Speed = 1.5f;

    public float stand_Height = 1.6f;
    public float crouch_Height = 1f;

    public bool is_Crouching;

    public float walk_Step_Distance = 0.4f;
    public float sprint_Step_Distance = 0.25f;
    public float crouch_Step_Distance = 0.5f;

    public float sprint_Value = 100f;
    public float sprint_Threshold = 10f;

    //attack Parameters
    public float fireRate = 15f;
    public float nextTimeToFire;
    public float damage = 20f;

    public bool is_Zoomed;
    public bool is_Aiming;

    

}
