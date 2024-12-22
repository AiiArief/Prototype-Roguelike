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
        var currentNode = PlayerManager.Instance.CurrentMapNode;
        if (currentNode == null)
            return;

        if (after == GameState.PreparationNextRoom)
        {
            var log = "Preparing to go to next room";
            log += "\nOption 1 : Choose next room";

            if (currentNode is MapNodeData_Preparation nodePreparation)
            {
                if (nodePreparation.CanChooseTalent)
                    log += "\nOption 2 : Choose talents (yes a perk tree goddamit) before going to next room";

                if (nodePreparation.CanChooseWeapon)
                    log += "\nOption 3 : Change your underwear i mean weapon before going to next room";
            }

            if (currentNode is MapNodeData_Shop nodeShop)
            {
                // todo : dapetin tradernya sapa
                log += "\nOption 2 : Barter with this trader or whatever this person is";
            }

            Log(log);
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

    void Log(string str)
    {
        if (!m_consoleText)
            return;

        var strTotal = $"{str}\n\n";
        m_consoleText.text += strTotal;
    }
}
