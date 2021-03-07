using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Level/Current Level")]
public class GameLevel : ScriptableObject
{
    private const int StartLevel = 1;

    public int Value;

    private void OnEnable()
    {
        Value = StartLevel;
    }
}
