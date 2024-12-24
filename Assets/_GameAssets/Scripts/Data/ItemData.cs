using System;
using UnityEngine;

namespace Roguelike.Data
{
    public enum WeaponAttachhmentType
    {
        Muzzle,
        Foregrip,
        Sight,
        Magazine,
        Stock
    }

    [Flags]
    public enum ArmorBodySlot
    {
        EyeAccessory,
        HeadAccessory,
        TopArmor,
        LeftThighArmor,
        RightThighArmor,
        LeftCalfArmor,
        RightCalfArmor,
        LeftUpperArmArmor,
        RightUpperArmArmor,
        LeftForearmArmor,
        RightForearmArmor,
    }

    public abstract class ItemData : ScriptableObject
    {
        [SerializeField] string m_displayName = "Useless Item";
        public string DisplayName => m_displayName;
    }

    [CreateAssetMenu(fileName = "Attachment_name", menuName = "Roguelike/Data/Item/Weapon Attachment")]
    public class ItemData_WeaponAttachment : ItemData
    {
        [SerializeField] WeaponAttachhmentType m_attachmentType;
        public WeaponAttachhmentType AttachhmentType => m_attachmentType;

        // TODO : attachment behaviour
    }

    [CreateAssetMenu(fileName = "Armor_name", menuName = "Roguelike/Data/Item/Armor")]
    public class ItemData_Armor : ItemData
    {
        [SerializeField] ArmorBodySlot m_bodySlot;
        public ArmorBodySlot BodySlot => m_bodySlot;

        // TODO : armor behaviour
    }

    [CreateAssetMenu(fileName = "Weapon_name", menuName = "Roguelike/Data/Item/Weapon")]
    public class ItemData_Weapon : ItemData
    {
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