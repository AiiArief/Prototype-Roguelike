using System;
using System.Collections;
using System.Collections.Generic;
using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike
{
    public enum GameState
    {
        None,
        Preparation,
        ChooseNextRoom,
        ChooseStrategy,
        Fighting,
        ChooseReward,
        GameOver
    }

    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public event Action OnGameManagerStarted;

        public delegate void OnGameStateChangedDelegate(GameState before, GameState after);
        public event OnGameStateChangedDelegate OnGameStateChanged;

        GameState m_currentGameState = GameState.None;
        public GameState CurrentGameState => m_currentGameState;

        public bool TryChangeGameState(GameState newState)
        {
            if (m_currentGameState == newState)
                return false;

            var beforeState = m_currentGameState;
            m_currentGameState = newState;
            OnGameStateChanged?.Invoke(beforeState, newState);
            return true;
        }


        private void Start()
        {
            StartCoroutine(WaitAllListenersAndThenStart());
        }

        IEnumerator WaitAllListenersAndThenStart()
        {
            yield return new WaitForEndOfFrame();

            TryChangeGameState(GameState.Preparation);
            OnGameManagerStarted?.Invoke();
        }
    }
}
