using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private const int StartingDestroyedWalls = 0;

    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform _ballSpawn;
    [SerializeField] private List<GameObject> _enemyWalls;
    [SerializeField] private GameLevel _currentLevel;

    private int _currentDestroyedWalls;

    private void WallDestroyed()
    {
        _currentDestroyedWalls++;
        RespawnBall();
        if (_currentDestroyedWalls < _enemyWalls.Count) return;
        else
        {
            RespawnLevel();
        }
    }

    private void RespawnLevel()
    {
        foreach (var wall in _enemyWalls)
        {
            wall.SetActive(true);
        }
        _currentDestroyedWalls = StartingDestroyedWalls;
        _currentLevel.Value++;
        RespawnBall();
        GameEvents.CallCompleteLevel();
    }

    private void RespawnBall()
    {
        _ball.SetActive(true);
        _ball.transform.position = _ballSpawn.position;
    }

    private void RegisterEvent()
    {
        GameEvents.WallDestroyed += WallDestroyed;
        GameEvents.RespawnBall += RespawnBall;
    }

    private void DeRegisterEvent()
    {
        GameEvents.WallDestroyed -= WallDestroyed;
        GameEvents.RespawnBall -= RespawnBall;
    }

    private void OnEnable()
    {
        RegisterEvent();
    }

    private void OnDisable()
    {
        DeRegisterEvent();
    }
}
