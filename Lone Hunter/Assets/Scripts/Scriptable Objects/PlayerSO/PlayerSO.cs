using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "Create Scriptable Objects/New Player SO")]
public class PlayerSO : ScriptableObject
{
    public float health;
    [Header("Movement Parameters")]
    public float move_Speed;
    public float player_Speed;
    public float gravity;
    public float jump_Force;
    
    [Header("Crouch Parameters")]
    public float crouch_Speed;
    public float stand_Height;
    public float crouch_Height;
    
    [Header("Sprint Parameters")]
    public float sprint_Speed;
    public float sprint_Value;
    public float sprint_ThreShold;

    //attack Parameters
    [Header("Attack Parameters")]
    public float fireRate;    
    public float damage;

    [Header("Score")]
    public int enemy_Killed;
    public int boar_Killed;
}
