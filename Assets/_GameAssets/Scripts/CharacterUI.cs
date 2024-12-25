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
            CharacterManager.OnPlayerGenerated += OnPlayerGenerated;
            CharacterManager.Instance.CurrentPlayer.OnHealthChanged += OnHealthChanged;
            CharacterManager.Instance.CurrentPlayer.OnWeaponChanged += OnWeaponChanged;
        }

        private void OnDisable()
        {
            CharacterManager.OnPlayerGenerated -= OnPlayerGenerated;
            CharacterManager.Instance.CurrentPlayer.OnHealthChanged -= OnHealthChanged;
            CharacterManager.Instance.CurrentPlayer.OnWeaponChanged -= OnWeaponChanged;
        }

        private void OnPlayerGenerated(Character_Player mainPlayer)
        {
            UpdateUI();
        }

        private void OnWeaponChanged(Item_Weapon before, Item_Weapon after)
        {
            UpdateUI();
        }

        private void OnHealthChanged(int before, int after)
        {
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