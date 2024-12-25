using System;
using System.Collections;
using System.Collections.Generic;
using Roguelike;
using Roguelike.Data;
using Roguelike.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Roguelike.UI
{
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
            var currentNode = CharacterManager.Instance.CurrentPlayer.CurrentMapNode;
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
                var nextNodeChoices = currentNode.NodeNextConnections;
                var log = "Please choose next room : ";
                var optionIndex = 1;

                if (nextNodeChoices.Length <= 0)
                    log += $"\nOption {optionIndex} : Portal to next area is waiting for you...";

                foreach (var node in nextNodeChoices)
                {
                    if (node is MapNodeData_Preparation nodePreparation)
                        log += $"\nOption {optionIndex} : It's a preparation room!";

                    if (node is MapNodeData_Shop nodeShop)
                        log += $"\nOption {optionIndex} : It's a shop, you can buy some shits here";

                    if (node is MapNodeData_Battle nodeBattle)
                    {
                        // TODO : kasih tau reward sama roomnnya gimana
                        log += $"\nOption {optionIndex} : Enemies are waiting for you in a mysterious room, there's a reward tho";
                    }

                    optionIndex++;
                }

                Log(log);
                return;
            }

            if (after == GameState.ChooseStrategy)
            {
                // TODO : pertama kali masuk kasih tau bakalan ada berapa musuh
                // TODO : jelasin ada berapa enemy di depan (+ jaraknya gimana), setiap strategi butuh berapa peluru & berapa persen sukses rate nya
                // TODO : kalo masih stealth, kasih tau bakalan berapa persen trigger alarm
                var log = "No enemy here ... go pick your reward";
                Log(log);
                return;
            }

            if (after == GameState.Fighting)
            {
                // TODO : kasih tau hasil dadu dan hasil fighting, kalo dadu gagal kasih tau kena berapa damage
                // TODO : kasih tau kalo trigger alarm
                var log = "Fighting... against who?";
                Log(log);
                return;
            }

            if (after == GameState.ChooseReward)
            {
                // TODO : list rewardnya apa aja
                var log = "No reward in this room, sadge...";
                Log(log);
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
}
