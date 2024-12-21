using System;
using System.Collections;
using System.Collections.Generic;
using Roguelike.Data;
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
        public static event Action OnGameManagerStarted;

        public delegate void OnGameMapGeneratedDelegate(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNode);
        public static event OnGameMapGeneratedDelegate OnGameMapGenerated;

        public delegate void OnGameStateChangedDelegate(GameState before, GameState after);
        public static event OnGameStateChangedDelegate OnGameStateChanged;

        GameState m_currentGameState = GameState.None;
        public GameState CurrentGameState => m_currentGameState;

        public static void InvokeOnGameMapGenerated(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNode)
        {
            OnGameMapGenerated?.Invoke(mapArea, mapAreaVariation, mapNode);
        }

        public void NextRoom()
        {
            TryChangeGameState(GameState.ChooseNextRoom);
        }

        public void OpenTalent()
        {
            Debug.Log("TODO : Opening talent");
        }

        public void OpenWeapon()
        {
            Debug.Log("TODO : Opening Weapon");
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
        bool TryChangeGameState(GameState newState)
        {
            if (m_currentGameState == newState)
                return false;

            var beforeState = m_currentGameState;
            m_currentGameState = newState;
            OnGameStateChanged?.Invoke(beforeState, newState);
            return true;
        }
    }
}
