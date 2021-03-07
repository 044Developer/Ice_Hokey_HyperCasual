using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyController 
{
    private Vector3 _target;
    public void EnemyMove(Transform enemyTransform, Transform targetTransform, float speed, int level)
    {
        _target = new Vector3(targetTransform.position.x, enemyTransform.position.y, enemyTransform.position.z);
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, _target, GetSpeed(speed, level));
    }

    private float GetSpeed(float speed, int level)
    {
        return speed * level * Time.deltaTime;
    }
}
