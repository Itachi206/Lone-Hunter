using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemySO", menuName = "Create Scriptable Objects/New Enemy SO")]
public class EnemySO : ScriptableObject
{
    public EnemyState enemy_State;
    [Header("Walk Parameters")]
    public float walk_Speed;
    public float run_Speed;

    [Header("Chase Parameters")]
    public float chase_Distance;
    public float current_Chase_Distance;

    [Header("Patrol Parameters")]
    public float patrol_Radius_Min;
    public float patrol_Radius_Max;
    public float patrol_For_This_Time;
    public float patrol_Timer;

    [Header("Attack Parameters")]
    public float attack_Distance;
    public float chase_After_Attack_distance;
    public float wait_Before_Attack;
    public float attack_Timer;
}
