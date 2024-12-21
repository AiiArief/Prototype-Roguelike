using System;
using Roguelike.Data;
using Roguelike.Utilities;

namespace Roguelike
{
    public class PlayerManager : MonoBehaviourSingleton<PlayerManager>
    {
        MapAreaData m_currentMapAreaData;
        public MapAreaData CurrentMapAreaData => m_currentMapAreaData;

        MapAreaVariationData m_currentMapAreaVariationData;
        public MapAreaVariationData CurrentMapAreaVariation => m_currentMapAreaVariationData;

        MapNodeData m_currentMapNodeData;
        public MapNodeData CurrentMapNode => m_currentMapNodeData;

        private void OnEnable()
        {
            GameManager.OnGameMapGenerated += OnGameMapGenerated;
        }

        private void OnDisable()
        {
            GameManager.OnGameMapGenerated -= OnGameMapGenerated;
        }

        void OnGameMapGenerated(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNode)
        {
            m_currentMapAreaData = mapArea;
            m_currentMapAreaVariationData = mapAreaVariation;
            m_currentMapNodeData = mapNode;
        }
    }
}