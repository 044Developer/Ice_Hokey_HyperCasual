using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayLevel : MonoBehaviour
{
    [SerializeField] private GameLevel _currentLevel;
    [SerializeField] private TextMeshProUGUI _levelText;

    private void OnEnable()
    {
        GameEvents.CompleteLevel += UpdateCurrentText;
    }

    private void Start()
    {
        UpdateCurrentText();
    }

    private void UpdateCurrentText()
    {
        _levelText.text = _currentLevel.Value.ToString();
    }

    private void OnDisable()
    {
        GameEvents.CompleteLevel -= UpdateCurrentText;
    }
}
