using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Data
{
    public abstract class MapNodeData : ScriptableObject
    {
        [SerializeField] Vector2 m_nodePosition;
        public Vector2 NodePosition => m_nodePosition;

        [SerializeField] MapNodeData[] m_nodeNextConnections;
        public MapNodeData[] NodeNextConnections => m_nodeNextConnections;
    }

    [CreateAssetMenu(fileName = "MapNodeData_Preparation_x-y", menuName = "Roguelike/Data/Map Node/Preparation")]
    public class MapNodeData_Preparation : MapNodeData
    {
        [SerializeField] bool m_canChooseWeapon;
        public bool CanChooseWeapon => m_canChooseWeapon;
        // choose weapon list?

        [SerializeField] bool m_canChooseTalent;
        public bool CanChooseTalent => m_canChooseTalent;
        // choose talent list?
    }

    [CreateAssetMenu(fileName = "MapNodeData_Battle_x-y", menuName = "Roguelike/Data/Map Node/Battle")]
    public class MapNodeData_Battle : MapNodeData
    {
        // wave nya gimana, abstract class wave, antara simple & boss
        // kalo boss wavenya turunannya beda

        // tipe reward gimana, persistent atau temporary
        // tipe jarak room nya gimana, jarak deket, menengah, jauh
        // tipe cahaya room gimana, gelap & terang
    }

    [CreateAssetMenu(fileName = "MapNodeData_Shop_x-y", menuName = "Roguelike/Data/Map Node/Shop")]
    public class MapNodeData_Shop : MapNodeData
    {
        // item list
    }
}
