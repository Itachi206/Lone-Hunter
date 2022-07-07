using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float damage = 2f;
    public float radius = 1f;
    public LayerMask layerMask;

    
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        if(hits.Length > 0)
        {
            if (hits[0].gameObject.tag == Tags.PLAYER_TAG)
            {
                hits[0].gameObject.GetComponent<PlayerView>().ApplyDamage(hits[0].gameObject.GetComponent<PlayerView>().PlayerController.playerModel.damage);
            }

            if (hits[0].gameObject.tag == Tags.ENEMY_TAG)
            {
                hits[0].gameObject.GetComponent<EnemyView>().ApplyDamage(hits[0].gameObject.GetComponent<EnemyView>().EnemyController.enemyModel.damage);
            }

            gameObject.SetActive(false);
        }
    }
}
