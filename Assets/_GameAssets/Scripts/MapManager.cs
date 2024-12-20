using Roguelike.Data;
using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike
{
    public class MapManager : MonoBehaviourSingleton<MapManager>
    {
        public delegate void OnMapManagerGeneratedDelegate(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNodel);
        public event OnMapManagerGeneratedDelegate OnMapManagerGenerated;

        [SerializeField] MapAreaData[] m_mapAreas;
        public MapAreaData[] MapAreas => m_mapAreas;

        private void OnEnable()
        {
            GameManager.Instance.OnGameManagerStarted += OnGameManagerStarted;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnGameManagerStarted -= OnGameManagerStarted;
        }

        void OnGameManagerStarted()
        {
            if (m_mapAreas.Length <= 0) // langsung menang?
                return;

            var currentArea = m_mapAreas[0];

            var currentAreaVariation = currentArea.GenerateCurrentAreaVariation();
            if (currentAreaVariation == null)
                return;

            var currentNode = currentAreaVariation.GenerateCurrentNode();
            if (currentNode == null)
                return;

            OnMapManagerGenerated?.Invoke(currentArea, currentAreaVariation, currentNode);
        }
    }
}