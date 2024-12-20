using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Roguelike.Data
{
    [CreateAssetMenu(fileName ="MapAreaVariationData", menuName = "Roguelike/Data/Map Area Variation")]
    public class MapAreaVariationData : ScriptableObject
    {
        [SerializeField] MapNodeData[] m_mapNodes;
        public MapNodeData[] MapNodes => m_mapNodes;
        
        public MapNodeData GenerateCurrentNode()
        {
            if (m_mapNodes.Length <= 0)
                return null;

            var startingNodeList = m_mapNodes.Where((x) => x.NodePosition.x == 0).ToList();
            if (startingNodeList.Count <= 0)
                return null;

            int rand = Random.Range(0, startingNodeList.Count);
            return m_mapNodes[rand];
        }
    }
}
