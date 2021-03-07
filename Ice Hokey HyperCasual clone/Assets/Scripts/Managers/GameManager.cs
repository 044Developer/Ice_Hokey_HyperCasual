using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    [SerializeField] private GameObject _player;    
    private static GameManager _instance;

    private void Start()
    {
        GamePause();
    }

    private void GameIsOn()
    {
        _player.SetActive(true);
    }

    private void GamePause()
    {
        _player.SetActive(false);
    }

    private void RegisterEvents()
    {
        GameEvents.GameIsOn += GameIsOn;
        GameEvents.GamePaused += GamePause;
    }

    private void DeRegisterEvents()
    {
        GameEvents.GameIsOn -= GameIsOn;
        GameEvents.GamePaused -= GamePause;
    }

    private void OnEnable()
    {
        RegisterEvents();
    }

    private void OnDisable()
    {
        DeRegisterEvents();
    }
}
