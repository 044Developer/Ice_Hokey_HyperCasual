using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public EnemyStats EnemyStats;

    [SerializeField] private Transform _target;
    [SerializeField] private GameLevel _currentLevel;

    private EnemyController _enemyController = new EnemyController();

    private void Update()
    {
        _enemyController.EnemyMove(transform, _target, EnemyStats.EnemySpeed, _currentLevel.Value);
    }
}
