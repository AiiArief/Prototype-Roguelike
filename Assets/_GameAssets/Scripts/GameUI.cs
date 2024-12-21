using System;
using System.Collections;
using System.Collections.Generic;
using Roguelike;
using Roguelike.Data;
using Roguelike.Utilities;
using UnityEngine;
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
            m_choicePanel_buttons[0].gameObject.SetActive(true);

            if (currentNodePreparation.CanChooseTalent)
                m_choicePanel_buttons[1].gameObject.SetActive(true);

            if (currentNodePreparation.CanChooseWeapon)
                m_choicePanel_buttons[2].gameObject.SetActive(true);
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
            button.gameObject.SetActive(false);

        m_choicePanel_textMode.SetActive(false);
        m_choicePanel_text.text = "Nothing to see here";

        return true;
    }
}
