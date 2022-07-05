using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
