using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Data
{
    [CreateAssetMenu(fileName ="MapAreaData", menuName = "Roguelike/Data/Map Area")]
    public class MapAreaData : ScriptableObject
    {
        [SerializeField] MapAreaVariationData[] m_mapVariations;
        public MapAreaVariationData[] MapVariations => m_mapVariations;

        public MapAreaVariationData GenerateCurrentAreaVariation()
        {
            if (m_mapVariations.Length <= 0)
                return null;

            int rand = Random.Range(0, m_mapVariations.Length);
            return m_mapVariations[rand];
        }
    }
}
