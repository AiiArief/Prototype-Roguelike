using System;
using System.Collections;
using System.Collections.Generic;
using Roguelike;
using Roguelike.Data;
using Roguelike.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConsoleUI : MonoBehaviourSingleton<ConsoleUI>
{
    [SerializeField] Text m_consoleText;

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += OnGameStateChanged;
        GameManager.OnGameMapGenerated += OnGameMapGenerated;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
        GameManager.OnGameMapGenerated -= OnGameMapGenerated;        
    }

    private void OnGameStateChanged(GameState before, GameState after)
    {
        if (before == GameState.None)
            return;

    }

    private void OnGameMapGenerated(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNodel)
    {

    }
}
