using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemySO", menuName = "Create Scriptable Objects/New Enemy SO")]
public class EnemySO : ScriptableObject
{
    public EnemyType EnemyType;
    public EnemyState enemy_State;

    [Header("Health Parameters")]
    public float health;

    [Header("Walk Parameters")]
    public float walk_Speed;
    public float run_Speed;

    [Header("Chase Parameters")]
    public float chase_Distance;    

    [Header("Patrol Parameters")]
    public float patrol_Radius_Min;
    public float patrol_Radius_Max;
    public float patrol_For_This_Time;    

    [Header("Attack Parameters")]
    public float attack_Distance;
    public float chase_After_Attack_distance;
    public float wait_Before_Attack;    
}
