using System;
using System.Collections;
using System.Collections.Generic;
using Roguelike;
using Roguelike.Data;
using Roguelike.Utilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameUI : MonoBehaviourSingleton<GameUI>
{
    [Header("Console Panel")]
    [SerializeField] Text m_consoleText;

    [Header("Choice Panel")]
    [SerializeField] GameObject m_choicePanel_choiceMode;
    [SerializeField] Button[] m_choicePanel_buttons;
    [SerializeField] GameObject m_choicePanel_textMode;
    [SerializeField] Text m_choicePanel_text;

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChanged += OnGameStateChanged;
        MapManager.Instance.OnMapManagerGenerated += OnMapManagerGenerated;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameStateChanged -= OnGameStateChanged;
        MapManager.Instance.OnMapManagerGenerated -= OnMapManagerGenerated;        
    }

    private void OnGameStateChanged(GameState before, GameState after)
    {
        if (before == GameState.None)
            return;

        RefreshUI();
    }

    private void OnMapManagerGenerated(MapAreaData mapArea, MapAreaVariationData mapAreaVariation, MapNodeData mapNodel)
    {
        RefreshUI();
    }

    void RefreshUI()
    {
        if (!TryResetChoicePanel())
            return;

        var currentNode = PlayerManager.Instance.CurrentMapNode;
        if (currentNode == null)
            return;

        if (currentNode is MapNodeData_Preparation currentNodePreparation)
        {
            m_choicePanel_choiceMode.SetActive(true);
            AddChoiceButton("Next Room", RefreshUI);

            if (currentNodePreparation.CanChooseTalent)
                AddChoiceButton("Choose Talent", RefreshUI);

            if (currentNodePreparation.CanChooseWeapon)
                AddChoiceButton("Choose Weapon", RefreshUI);
            
            return;
        }
    }

    bool TryResetChoicePanel()
    {
        if (!m_choicePanel_choiceMode || 
            !m_choicePanel_textMode || 
            !m_choicePanel_text ||
            m_choicePanel_buttons.Length < 5)
            return false;

        m_choicePanel_choiceMode.SetActive(false);
        foreach (var button in m_choicePanel_buttons)
        {
            button.gameObject.SetActive(false);
            button.onClick.RemoveAllListeners();
        }

        m_choicePanel_textMode.SetActive(false);
        m_choicePanel_text.text = "";

        return true;
    }

    void AddChoiceButton(string text, UnityAction onClickAction)
    {
        foreach(var button in m_choicePanel_buttons)
        {
            if (button.gameObject.activeSelf)
                continue;

            button.gameObject.SetActive(true);
            button.onClick.AddListener(onClickAction);
            button.GetComponentInChildren<Text>().text = text;
            break;
        }
    }
}
