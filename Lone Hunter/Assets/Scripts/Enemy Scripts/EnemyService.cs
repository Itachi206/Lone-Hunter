using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    [SerializeField] private EnemyView EnemyPrefab;
    [SerializeField] private EnemyView BoarPrefab;
    [SerializeField] private EnemySO enemySO;
    [SerializeField] private EnemySO boarSO;

    void Start()
    {
        SpawnEnemy();
        //SpawnBoar();
    }

    private void SpawnEnemy()
    {
        EnemyModel enemyModel = new EnemyModel(enemySO);
        EnemyController enemyController = new EnemyController(EnemyPrefab, enemyModel);        
    }

    private void SpawnBoar()
    {
        EnemyModel boarModel = new EnemyModel(boarSO);
        EnemyController boarController = new EnemyController(BoarPrefab, boarModel);
    }

}
