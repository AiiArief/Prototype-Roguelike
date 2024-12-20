using System.Collections;
using System.Collections.Generic;
using Roguelike.Utilities;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviourSingleton<GameUI>
{
    [SerializeField] Text m_consoleText;
    public Text consoleText => m_consoleText;

    [SerializeField] Button[] m_buttons;
    public Button[] buttons => m_buttons;
}
