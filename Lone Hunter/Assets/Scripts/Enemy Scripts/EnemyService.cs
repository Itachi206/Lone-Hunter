using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : GenericMonoSingleton<EnemyService>
{
    [SerializeField] private EnemyView EnemyPrefab, BoarPrefab;
    [SerializeField] private EnemySO enemySO, boarSO;

    public Transform[] Enemy_SpawnPoints, boar_SpawnPoints;
    [SerializeField] private int enemy_Count, boar_Count;
    private int initial_Enemy_Count, initital_Boar_Count;
    public float wait_Before_Spawn_Enemy_Time;


    void Start()
    {
        initial_Enemy_Count = enemy_Count;
        initital_Boar_Count = boar_Count;

        SpawnRandomEnemy();
        StartCoroutine(CheckToSpawnEnemies());

    }

    void SpawnRandomEnemy()
    {
        SpawnEnemy();
        SpawnBoar();
    }
    private void SpawnEnemy()
    {
        int index = 0;
        for(int i = 0; i < enemy_Count; i++)
        {
            if(index >= Enemy_SpawnPoints.Length)
            {
                index = 0;
            }

            EnemyModel enemyModel = new EnemyModel(enemySO);
            EnemyController enemyController = new EnemyController(EnemyPrefab, enemyModel, Enemy_SpawnPoints[index].position);

            index++;
        }

        enemy_Count = 0;                
    }

    private void SpawnBoar()
    {
        int index = 0;
        for (int i = 0; i < boar_Count; i++)
        {
            if(index >= boar_SpawnPoints.Length)
            {
                index = 0;
            }

            EnemyModel boarModel = new EnemyModel(boarSO);
            EnemyController boarController = new EnemyController(BoarPrefab, boarModel, boar_SpawnPoints[index].position);
        }

        boar_Count = 0;
    }

    IEnumerator CheckToSpawnEnemies()
    {
        yield return new WaitForSeconds(wait_Before_Spawn_Enemy_Time);
        SpawnEnemy();
        SpawnBoar();

        StartCoroutine(CheckToSpawnEnemies());
    }

    public void EnemyDied(bool isEnemy)
    {
        if(isEnemy)
        {
            enemy_Count++;
            
            if(enemy_Count > initial_Enemy_Count)
            {
                enemy_Count = initial_Enemy_Count;
            }
        }
        else
        {
            boar_Count++;

            if(boar_Count > initital_Boar_Count)
            {
                boar_Count = initital_Boar_Count;
            }
        }
    }

    public void StopSpawning()
    {
        StopCoroutine(CheckToSpawnEnemies());
    }
}
