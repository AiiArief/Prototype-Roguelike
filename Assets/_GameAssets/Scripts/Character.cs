using System;
using Roguelike.Data;
using Unity.Collections;
using UnityEngine;

namespace Roguelike
{
    public abstract class Character : MonoBehaviour
    {
        public delegate void OnHealthChangedDelegate(int before, int after);
        public event OnHealthChangedDelegate OnHealthChange;

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

                OnHealthChange?.Invoke(before, m_currentHealth);
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
        // TODO dapetin current weapon, kalo ga ada balikin ke default
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