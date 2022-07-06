using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController 
{
    public EnemyView enemyView;
    public EnemyModel enemyModel;
    public EnemyController(EnemyView _enemyView, EnemyModel _enemyModel)
    {
        enemyModel = _enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView);

        enemyView.EnemyController = this;
    }

    internal void PatrolState()
    {
        // tell nav agent that he can move
        enemyView.navAgent.isStopped = false;
        enemyView.navAgent.speed = enemyModel.walk_Speed;

        //add to the patrol timer
        enemyModel.patrol_Timer += Time.deltaTime;

        if (enemyModel.patrol_Timer > enemyModel.patrol_For_This_Time)
        {
            SetNewRandomDestination();
            enemyModel.patrol_Timer = 0f;
        }

        if (enemyView.navAgent.velocity.sqrMagnitude > 0)
        {
            enemyView.enemy_Anim.Walk(true);
        }
        else
        {
            enemyView.enemy_Anim.Walk(false);
        }

        //test the distance between enemy and the player
        if(Vector3.Distance(enemyView.transform.position, enemyView.target.position) <= enemyModel.chase_Distance)
        {
            enemyView.enemy_Anim.Walk(false);
            enemyModel.enemy_State = EnemyState.CHASE;
            //patrol sound
        }
    }//Patrol

    private void SetNewRandomDestination()
    {
        float rand_Radius = UnityEngine.Random.Range(enemyModel.patrol_Radius_Min, enemyModel.patrol_Radius_Max);

        Vector3 randDir = UnityEngine.Random.insideUnitSphere * rand_Radius;
        randDir += enemyView.transform.position;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randDir, out navHit, rand_Radius, -1);

        enemyView.navAgent.SetDestination(navHit.position);
    }//Set New Destination

    internal void ChaseState()
    {
        // enable the agent to move again
        enemyView.navAgent.isStopped = false;
        enemyView.navAgent.speed = enemyModel.run_Speed;

        //set the player's position as the destinatin
        // because enemy will chase the player 
        enemyView.navAgent.SetDestination(enemyView.target.position);

        if (enemyView.navAgent.velocity.sqrMagnitude > 0)
        {
            enemyView.enemy_Anim.Run(true);
        }
        else
        {
            enemyView.enemy_Anim.Run(false);
        }

        //if the distance between enemy and player is less than attack distance
        if (Vector3.Distance(enemyView.transform.position, enemyView.target.position) <= enemyModel.attack_Distance)
        {
            enemyView.enemy_Anim.Walk(false);
            enemyView.enemy_Anim.Run(false);

            enemyModel.enemy_State = EnemyState.ATTACK;

            if(enemyModel.chase_Distance != enemyModel.current_Chase_Distance)
            {
                enemyModel.chase_Distance = enemyModel.current_Chase_Distance;
            }
        }
        else if (Vector3.Distance(enemyView.transform.position, enemyView.target.position) > enemyModel.chase_Distance)
        {
            //when player run away from enemy switch to patrol state
            //stop running
            enemyView.enemy_Anim.Run(false);

            enemyModel.enemy_State = EnemyState.PATROL;

            //reset the patrol timer so that the function
            //can calculate the new patrol destination right away
            enemyModel.patrol_Timer = enemyModel.patrol_For_This_Time;

            //reset the chase distance to preview
            if(enemyModel.chase_Distance != enemyModel.current_Chase_Distance)
            {
                enemyModel.chase_Distance = enemyModel.current_Chase_Distance;
            }
        }
    }

    internal void AttackState()
    {
        enemyView.navAgent.velocity = Vector3.zero;
        enemyView.navAgent.isStopped = true;

        enemyModel.attack_Timer += Time.deltaTime;

        if(enemyModel.attack_Timer > enemyModel.wait_Before_Attack)
        {
            enemyView.enemy_Anim.Attack();
            EnemyAttack();
            enemyModel.attack_Timer = 0f;
            //attack sound
        }

        if(Vector3.Distance(enemyView.transform.position, enemyView.target.position) > enemyModel.attack_Distance + enemyModel.chase_After_Attack_distance)
        {
            enemyModel.enemy_State = EnemyState.CHASE;
        }
    }    

    public void ApplyDamage(float damage)
    {
        Debug.Log(enemyModel.IsDead);
        Debug.Log("Enemy Name " + enemyView.gameObject.name + " health : " + enemyModel.health);
        if (enemyModel.IsDead)
            return;

        enemyModel.health -= damage;


        if(enemyModel.enemy_State == EnemyState.PATROL)
        {
            enemyModel.chase_Distance = 50f;
        }

        if(enemyModel.health <= 0f)
        {
            EnemyDied();
            enemyModel.IsDead = true;
        }
    }

    private void EnemyDied()
    {
        if(enemyModel.EnemyType == EnemyType.Cannibal)
        {
            enemyView.GetComponent<Animator>().enabled = false;
            enemyView.GetComponent<BoxCollider>().isTrigger = false;
            enemyView.GetComponent<Rigidbody>().AddTorque(-enemyView.transform.forward * 5f);
            enemyView.navAgent.enabled = false;
            enemyView.enemy_Anim.enabled = false;
            //enemyView.enabled = false;
            enemyView.gameObject.SetActive(false);
        }

        if(enemyModel.EnemyType == EnemyType.Boar)
        {
            enemyView.navAgent.velocity = Vector3.zero;
            enemyView.navAgent.isStopped = true;
            enemyView.enemy_Anim.Dead();
            enemyView.enabled = false;
        }
    }

    public void EnemyAttack()
    {
        Collider[] hits = Physics.OverlapSphere(enemyView.attack_Point.transform.position, enemyView.radius, enemyView.layerMask);

        if (hits.Length > 0)
        {
            hits[0].gameObject.GetComponent<PlayerView>().ApplyDamage(enemyModel.damage);
         
            enemyView.Turn_Off_AttackPoint();
        }
    }
}
