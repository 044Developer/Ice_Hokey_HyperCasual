using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    public delegate void GameEvent();

    public static event GameEvent BallLaunched;
    public static event GameEvent WallDestroyed;
    public static event GameEvent CompleteLevel;
    public static event GameEvent RespawnBall;

    public static event GameEvent GameIsOn;
    public static event GameEvent GamePaused;

    public static void CallBallLaunched()
    {
        if (BallLaunched != null)
        {
            BallLaunched();
        }
    }

    public static void CallWallDestroyed()
    {
        if (WallDestroyed != null)
        {
            WallDestroyed();
        }
    }

    public static void CallCompleteLevel()
    {
        if (CompleteLevel != null)
        {
            CompleteLevel();
        }
    }

    public static void CallRespawnBall()
    {
        if (RespawnBall != null)
        {
            RespawnBall();
        }
    }

    public static void CallGameIsOn()
    {
        if (GameIsOn != null)
        {
            GameIsOn();
        }
    }
    
    public static void CallGamePaused()
    {
        if (GamePaused != null)
        {
            GamePaused();
        }
    }
}
