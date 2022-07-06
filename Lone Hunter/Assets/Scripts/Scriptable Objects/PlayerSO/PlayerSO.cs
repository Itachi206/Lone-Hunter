using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Create Scriptable Objects/New Player SO")]
public class PlayerSO : ScriptableObject
{
    [Header("Movement Parameters")]
    public float move_Speed;
    public float player_Speed;
    public float gravity;
    public float jump_Force;
    
    [Header("Crouch Parameters")]
    public float crouch_Speed;
    public float stand_Height;
    public float crouch_Height;    

    //public float walk_Step_Distance = 0.4f;
    //public float sprint_Step_Distance = 0.25f;
    //public float crouch_Step_Distance = 0.5f;

    [Header("Sprint Parameters")]
    public float sprint_Speed;    
    
    //attack Parameters
    [Header("Attack Parameters")]
    public float fireRate;    
    public float damage;
    
}
