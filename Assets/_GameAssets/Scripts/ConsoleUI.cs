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
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState before, GameState after)
    {
        if (after == GameState.PreparationNextRoom)
        {
            // baca situasi ruangan gimana
            return;
        }

        if (after == GameState.ChooseNextRoom)
        {
            // baca ruangan selanjutnya gimana
            return;
        }

        if (after == GameState.ChooseStrategy)
        {
            // baca musuh ruangan gimana
            return;
        }

        if (after == GameState.Fighting)
        {
            // baca ruangan selanjutnya gimana
            return;
        }

        if (after == GameState.ChooseReward)
        {
            // baca dapet reward apa aja
            return;
        }
    }
}
