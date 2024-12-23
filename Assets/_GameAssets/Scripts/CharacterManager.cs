using System;
using System.Collections.Generic;
using Roguelike.Data;
using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike
{
    public class CharacterManager : MonoBehaviourSingleton<CharacterManager>
    {
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
            GameManager.OnGameMapGenerated += OnGameMapGenerated;
        }

        private void OnDisable()
        {
            GameManager.OnGameMapGenerated -= OnGameMapGenerated;
        }

        void OnGameMapGenerated(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNode)
        {
            if (!m_playerPrefab)
                return;

            m_currentPlayer = Instantiate(m_playerPrefab, transform);
            m_currentPlayer.SetMap(mapArea, mapAreaVariation, mapNode);
        }
    }
}