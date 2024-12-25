using System;
using Roguelike.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Roguelike.UI
{
    public class CharacterUI : MonoBehaviourSingleton<CharacterUI>
    {
        [Header("Text Mode")]
        [SerializeField] Text m_equipmentText;

        private void OnEnable()
        {
            GameManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDisable()
        {
            GameManager.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState before, GameState after)
        {
            if (before != GameState.None)
                return;

            // TODO : listener ke current player, tapi current playernya ada kemungkinan blom ke instantaite
            UpdateUI();
        }

        void UpdateUI()
        {
            if (!m_equipmentText)
                return;

            var currentPlayer = CharacterManager.Instance.CurrentPlayer;
            if (!currentPlayer)
                return;

            m_equipmentText.text = $"{currentPlayer.CharacterData.DisplayName}\n";
            m_equipmentText.text += $"{currentPlayer.CurrentHealth} / {currentPlayer.CurrentMaxHealth}\n\n";

            var currentWeapon = currentPlayer.CurrentWeapon;
            if (currentWeapon)
            {
                m_equipmentText.text += $"{currentWeapon.ItemData.DisplayName}\n";
                m_equipmentText.text += $"{currentWeapon.CurrentMagazine} / {currentWeapon.CurrentMagazineCapacity}\n";
            }

            // current armor
        }
    }
}