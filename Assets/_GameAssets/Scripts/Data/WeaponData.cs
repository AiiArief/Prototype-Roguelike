using UnityEngine;

namespace Roguelike.Data
{
    [CreateAssetMenu(fileName = "Weapon_name", menuName = "Roguelike/Data/Weapon")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] string m_displayName = "Default Close Combat";
        public string DisplayName => m_displayName;

        // bikin tag? close combat, bisa di upgrade, dll

        [SerializeField] int m_baseMagazineCapacity = 1;
        public int BaseMagazineCapacity => m_baseMagazineCapacity;

        [SerializeField] int m_baseDamage = 10;
        public int BaseDamage => m_baseDamage;

        [SerializeField] int m_baseAccuracy = 95;
        public int BaseAccuracy => m_baseAccuracy;

        [SerializeField] int m_baseFireRate = 200;
        public int BaseFireRate => m_baseFireRate;

        [SerializeField] int m_baseReloadSpeed = 0;
        public int BaseReloadSpeed => m_baseReloadSpeed;

        [SerializeField] int m_baseEvasionSkill = 25;
        public int BaseEvasionSkill => m_baseEvasionSkill;

        [SerializeField] int m_attackLoudness = 40;
        public int AttackLoudness => m_attackLoudness;

        [SerializeField] int m_baseMaxEffectiveRange = 3;
        public int BaseMaxEffectiveRange => m_baseMaxEffectiveRange;
    }
}