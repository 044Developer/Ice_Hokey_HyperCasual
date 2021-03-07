using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _resumeGame;
    [SerializeField] private Button _endGame;
    [SerializeField] private Button _restartGame;
    [SerializeField] private Button _pauseGame;

    [Header("Panels")]
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _scorePanel;


    private void Start()
    {
        _startGame.onClick.AddListener(OnStartGame);
        _resumeGame.onClick.AddListener(OnGameResume);
        _endGame.onClick.AddListener(OnGameExit);
        _restartGame.onClick.AddListener(OnGameRestart);
        _restartGame.onClick.AddListener(OnGameRestart);
        _pauseGame.onClick.AddListener(OnGamePaused);
    }

    private void OnStartGame()
    {
        _startMenu.SetActive(false);
        _pausePanel.SetActive(true);
        _scorePanel.SetActive(true);
        GameEvents.CallGameIsOn();
    }

    private void OnGameExit()
    {
        Application.Quit();
    }

    private void OnGamePaused()
    {
        _pauseMenu.SetActive(true);
        _pausePanel.SetActive(false);
        GameEvents.CallGamePaused();
    }

    private void OnGameResume()
    {
        _pauseMenu.SetActive(false);
        _pausePanel.SetActive(true);
        GameEvents.CallGameIsOn();
    }
    
    private void OnGameRestart()
    {
        _pauseMenu.SetActive(false);
        _pausePanel.SetActive(true);
        _scorePanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
