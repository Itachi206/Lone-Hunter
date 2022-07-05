using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    [SerializeField] private EnemyView enemyView;
    [SerializeField] private EnemySO enemySO;

    void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        EnemyModel enemyModel = new EnemyModel(enemySO);
        EnemyController enemyController = new EnemyController(enemyView, enemyModel);        
    }
   
}
