using System;
using Roguelike.Data;
using Unity.Collections;
using UnityEngine;

namespace Roguelike
{
    public abstract class Character : MonoBehaviour
    {
        public delegate void OnHealthChangedDelegate(int before, int after);
        public event OnHealthChangedDelegate OnHealthChanged;

        public delegate void OnWeaponChangedDelegate(Item_Weapon before, Item_Weapon after);
        public event OnWeaponChangedDelegate OnWeaponChanged;

        [SerializeField] CharacterData m_characterData;
        public CharacterData CharacterData => m_characterData;

        [ReadOnly] int m_currentHealth;
        public int CurrentHealth { 
            get
            {
                return m_currentHealth;
            }
            set
            {
                if (value == m_currentHealth)
                    return;

                var before = m_currentHealth;
                var clamped = Mathf.Clamp(value, 0, CurrentMaxHealth);
                m_currentHealth = clamped;

                OnHealthChanged?.Invoke(before, m_currentHealth);
            } 
        }

        public int CurrentMaxHealth
        {
            get
            {
                return m_characterData.BaseMaxHealth; // + talents
            }
        }

        public int CurrentArmor
        {
            get
            {
                return 0; // + gabungan semua inventory, talents
            }
        }

        // TODO bikin item list
        [ReadOnly] Item_Weapon m_currentWeapon;
        public Item_Weapon CurrentWeapon
        {
            get
            {
                if (!m_currentWeapon)
                {
                    m_currentWeapon = Instantiate(m_characterData.DefaultWeaponPrefab, transform);
                    OnWeaponChanged?.Invoke(null, m_currentWeapon);
                }

                return m_currentWeapon;
            }
            set
            {
                var before = m_currentWeapon;
                if (m_currentWeapon)
                    Destroy(m_currentWeapon.gameObject);

                var newWeapon = value;
                if (!newWeapon)
                    m_currentWeapon = Instantiate(m_characterData.DefaultWeaponPrefab, transform);

                m_currentWeapon = newWeapon;
                OnWeaponChanged?.Invoke(before, m_currentWeapon);
            }
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }
    }

    public class Character_Player : Character
    {
        MapAreaData m_currentMapAreaData;
        public MapAreaData CurrentMapAreaData => m_currentMapAreaData;

        MapAreaVariationData m_currentMapAreaVariationData;
        public MapAreaVariationData CurrentMapAreaVariation => m_currentMapAreaVariationData;

        MapNodeData m_currentMapNodeData;
        public MapNodeData CurrentMapNode => m_currentMapNodeData;

        public void SetMap(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNode)
        {
            m_currentMapAreaData = mapArea;
            m_currentMapAreaVariationData = mapAreaVariation;
            m_currentMapNodeData = mapNode;
        }
    }

    public class Character_NonPlayer : Character
    {

    }
}