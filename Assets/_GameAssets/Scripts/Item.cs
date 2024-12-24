using Roguelike.Data;
using UnityEngine;
using Unity.Collections;

namespace Roguelike
{
    public abstract class Item : MonoBehaviour
    {
        public ItemData GenericItemData
        {
            get
            {
                if (TryGetItemAs<Item_WeaponAttachment>(out var attachment))
                    return attachment.ItemData;

                if (TryGetItemAs<Item_Armor>(out var armor))
                    return armor.ItemData;

                if (TryGetItemAs<Item_Weapon>(out var weapon))
                    return weapon.ItemData;

                return default;
            }
        }

        public bool TryGetItemAs<T>(out T output) where T : Item
        {
            output = default;

            if (this is T itemInheritance)
            {
                output = itemInheritance;
                return true;
            }

            return false;
        }
    }

    public class Item_WeaponAttachment : Item
    {
        [SerializeField] ItemData_WeaponAttachment m_itemData;
        public ItemData_WeaponAttachment ItemData => m_itemData;
    }

    public class Item_Armor : Item
    {
        [SerializeField] ItemData_Armor m_itemData;
        public ItemData_Armor ItemData => m_itemData;
    }

    public class Item_Weapon : Item
    {
        [SerializeField] ItemData_Weapon m_itemData;
        public ItemData_Weapon ItemData => m_itemData;

        public int CurrentMagazineCapacity
        {
            get
            {
                return m_itemData.BaseMagazineCapacity; // + attachment
            }
        }

        [ReadOnly] int m_currentMagazine = 1;
        public int CurrentMagazine
        {
            get
            {
                return m_currentMagazine;
            }
            set
            {
                if (value == m_currentMagazine)
                    return;

                var before = m_currentMagazine;
                var clamped = Mathf.Clamp(value, 0, CurrentMagazineCapacity);
                m_currentMagazine = clamped;
            }
        }
    }
}