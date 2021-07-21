using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum State
    {
        Playing,Paused,Gameover
    }


public static class GameState
{
    private static State gameState;

    public static Action OnGameOver;
    public static Action OnPaused;
    public static Action OnPlaying;

    public static State GetGameState()
    {
        switch(state)
        {
            case State.Playing:
                SetStatePlaying();

            case State.Paused:
                SetStatePaused();

            case State.Gameover:
                SetStateGameOver();

        }
    }

    private static void SetStateGameOver()
    {
        gameState = State;
    }

    private static void SetStatePaused()
    {
        
    }

    private static void SetStatePlaying()
    {
        
    }
}