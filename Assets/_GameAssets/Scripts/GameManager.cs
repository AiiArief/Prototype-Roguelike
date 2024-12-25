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
        PreparationNextRoom,
        ChooseNextRoom,
        ChooseStrategy,
        Fighting,
        ChooseReward,
        GameOver
    }

    public class GameManager : MonoBehaviourSingleton<GameManager>
    {
        public static event Action OnGameManagerStarted;

        public delegate void OnGameStateChangedDelegate(GameState before, GameState after);
        public static event OnGameStateChangedDelegate OnGameStateChanged;

        GameState m_currentGameState = GameState.None;
        public GameState CurrentGameState => m_currentGameState;

        public void ChooseNextRoom()
        {
            TryChangeGameState(GameState.ChooseNextRoom);
        }

        public void NextRoom(int index = -1)
        {
            // kalo ga ada koneksi : area selanjutnya
            // kalo area selanjutnya abis : tamat
            // semua koneksi 
            throw new NotImplementedException();
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
            StartCoroutine(WaitAllManagersAndThenStart());
        }

        private void OnEnable()
        {
            MapManager.OnMapGenerated += OnMapGenerated;
        }

        private void OnDisable()
        {
            MapManager.OnMapGenerated -= OnMapGenerated;
        }

        private void OnMapGenerated(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNode)
        {
            TryChangeGameState(GameState.PreparationNextRoom);
        }

        IEnumerator WaitAllManagersAndThenStart()
        {
            yield return new WaitForEndOfFrame();

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
