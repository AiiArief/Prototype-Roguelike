using UnityEngine;

namespace Roguelike.Data
{
    [CreateAssetMenu(fileName = "Character_name", menuName = "Roguelike/Data/Character")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] string m_displayName = "Generic Character";
        public string DisplayName => m_displayName;

        [SerializeField] int m_baseMaxHealth = 100;
        public int BaseMaxHealth => m_baseMaxHealth;

        [SerializeField] Item_Weapon m_defaultWeaponPrefab;
        public Item_Weapon DefaultWeaponPrefab => m_defaultWeaponPrefab;

        // base starter talents data
    }
}