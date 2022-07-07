using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : GenericMonoSingleton<EnemyService>
{
    public EnemyController currentEnemy;
    [SerializeField] private EnemyView EnemyPrefab, BoarPrefab;
    [SerializeField] private EnemySO enemySO, boarSO;

    public Transform[] Enemy_SpawnPoints, boar_SpawnPoints;
    public int enemy_Count, boar_Count;
    private int initial_Enemy_Count, initital_Boar_Count;
    public float wait_Before_Spawn_Enemy_Time;


    void Start()
    {
        initial_Enemy_Count = enemy_Count;
        initital_Boar_Count = boar_Count;

        SpawnRandomEnemy();        
    }

    void SpawnRandomEnemy()
    {
        SpawnEnemy();
        SpawnBoar();
    }
    private void SpawnEnemy()
    {
        for(int i = 0; i < enemy_Count; i++)
        {
            EnemyModel enemyModel = new EnemyModel(enemySO);
            EnemyController enemyController = new EnemyController(EnemyPrefab, enemyModel, Enemy_SpawnPoints[i].position);
        }                       
    }

    private void SpawnBoar()
    {
        for (int i = 0; i < boar_Count; i++)
        {
            EnemyModel boarModel = new EnemyModel(boarSO);
            EnemyController boarController = new EnemyController(BoarPrefab, boarModel, boar_SpawnPoints[i].position);
        }
    }    
}
