using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public EnemyType EnemyType;
    public EnemyState enemy_State;

    public float health;
    public float damage;
    public bool IsDead;

    public float walk_Speed;
    public float run_Speed;

    public float chase_Distance;
    public float current_Chase_Distance;

    public float patrol_Radius_Min;
    public float patrol_Radius_Max;
    public float patrol_For_This_Time;
    public float patrol_Timer;

    public float attack_Distance;
    public float chase_After_Attack_distance;
    public float wait_Before_Attack;
    public float attack_Timer;

    public EnemyModel(EnemySO _enemySO)
    {
        enemy_State = _enemySO.enemy_State;
        health = _enemySO.health;
        damage = _enemySO.damage;

         walk_Speed = _enemySO.walk_Speed;
        run_Speed = _enemySO.run_Speed;

        chase_Distance = _enemySO.chase_Distance;        

        patrol_Radius_Min = _enemySO.patrol_Radius_Min;
        patrol_Radius_Max = _enemySO.patrol_Radius_Max;
        patrol_For_This_Time = _enemySO.patrol_For_This_Time;        

        attack_Distance = _enemySO.attack_Distance;
        chase_After_Attack_distance = _enemySO.chase_After_Attack_distance;
        wait_Before_Attack = _enemySO.wait_Before_Attack;        
    }
}

