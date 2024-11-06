using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject _startPanel;
    private Opponents[] _opponentsArray;
    public TextMeshProUGUI coinCountText;

    private void Start()
    {
        // Sahnedeki tüm Opponents bileþenlerini bul
        _opponentsArray = FindObjectsOfType<Opponents>();
    }

    public void TapToStart()
    {
        _startPanel.SetActive(false);

        // Her bir Opponents bileþeni için AgentStart'ý çaðýr
        foreach (var opponent in _opponentsArray)
        {
            opponent.AgentStart();
        }
    }
}