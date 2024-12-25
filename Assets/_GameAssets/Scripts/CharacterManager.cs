using System;
using System.Collections.Generic;
using Roguelike.Data;
using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike
{
    public class CharacterManager : MonoBehaviourSingleton<CharacterManager>
    {
        public delegate void OnPlayerGeneratedDelegate(Character_Player mainPlayer);
        public static event OnPlayerGeneratedDelegate OnPlayerGenerated;

        [SerializeField] Character_Player m_playerPrefab;

        Character_Player m_currentPlayer;
        public Character_Player CurrentPlayer => m_currentPlayer;

        public List<Character> GetCharacterListInThisRoom(bool includePlayer = true)
        {
            var list = new List<Character>();
            foreach (Transform child in transform)
            {
                if (!child.TryGetComponent<Character>(out var character))
                    continue;

                if (!includePlayer && character is Character_Player)
                    continue;

                list.Add(character);
            }

            return list;
        }

        private void OnEnable()
        {
            GameManager.OnGameManagerStarted += OnGameManagerStarted;
            MapManager.OnMapGenerated += OnMapGenerated;
        }

        private void OnDisable()
        {
            GameManager.OnGameManagerStarted -= OnGameManagerStarted;
            MapManager.OnMapGenerated -= OnMapGenerated;
        }

        private void OnGameManagerStarted()
        {
            InstantiatePlayer();
        }

        private void OnMapGenerated(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNode)
        {
            if (!m_currentPlayer)
                InstantiatePlayer();

            m_currentPlayer.SetMap(mapArea, mapAreaVariation, mapNode);
        }

        void InstantiatePlayer()
        {
            if (!m_playerPrefab || m_currentPlayer)
                return;

            m_currentPlayer = Instantiate(m_playerPrefab, transform);
            OnPlayerGenerated?.Invoke(m_currentPlayer);
        }
    }
}