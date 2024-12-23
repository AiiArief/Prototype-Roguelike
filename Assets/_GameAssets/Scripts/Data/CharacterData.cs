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

        [SerializeField] WeaponData m_defaultWeapon;
        public WeaponData DefaultWeapon => m_defaultWeapon;

        // base starter talents data
    }
}