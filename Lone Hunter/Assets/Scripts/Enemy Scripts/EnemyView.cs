using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public EnemyController EnemyController;
    [HideInInspector] public EnemyAnimator enemy_Anim;
    [HideInInspector] public NavMeshAgent navAgent;    

    [HideInInspector] public Transform target;
    public GameObject attack_Point;
   

    private void Awake()
    {
        enemy_Anim = GetComponent<EnemyAnimator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        target = GameObject.FindObjectOfType<PlayerView>().transform;
        EnemyController.enemyModel.enemy_State = EnemyState.PATROL;
        EnemyController.enemyModel.patrol_Timer = EnemyController.enemyModel.patrol_For_This_Time;
        EnemyController.enemyModel.attack_Timer = EnemyController.enemyModel.wait_Before_Attack;
        EnemyController.enemyModel.current_Chase_Distance = EnemyController.enemyModel.chase_Distance;
    }

    void Update()
    {
        StateInitialization();
    }

    private void StateInitialization()
    {        
        if(EnemyController.enemyModel.enemy_State == EnemyState.PATROL)
        {
            EnemyController.PatrolState();
        }

        if (EnemyController.enemyModel.enemy_State == EnemyState.CHASE)
        {
            EnemyController.ChaseState();
        }

        if (EnemyController.enemyModel.enemy_State == EnemyState.ATTACK)
        {
            EnemyController.AttackState();
        }
    }

    void Turn_On_AttackPoint()
    {
        attack_Point.SetActive(true);
    }

    void Turn_Off_AttackPoint()
    {
        if (attack_Point.activeInHierarchy)
        {
            attack_Point.SetActive(false);
        }
    }

}
