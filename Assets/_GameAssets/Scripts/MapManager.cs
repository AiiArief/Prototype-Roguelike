using Roguelike.Data;
using Roguelike.Utilities;
using UnityEngine;

namespace Roguelike
{
    public class MapManager : MonoBehaviourSingleton<MapManager>
    {
        [SerializeField] MapAreaData[] m_mapAreas;
        public MapAreaData[] MapAreas => m_mapAreas;

        private void OnEnable()
        {
            GameManager.OnGameManagerStarted += OnGameManagerStarted;
        }

        private void OnDisable()
        {
            GameManager.OnGameManagerStarted -= OnGameManagerStarted;
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

            GameManager.Instance.InvokeOnGameMapGenerated(currentArea, currentAreaVariation, currentNode);
        }
    }
}