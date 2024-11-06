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
        // Sahnedeki t�m Opponents bile�enlerini bul
        _opponentsArray = FindObjectsOfType<Opponents>();
    }

    public void TapToStart()
    {
        _startPanel.SetActive(false);

        // Her bir Opponents bile�eni i�in AgentStart'� �a��r
        foreach (var opponent in _opponentsArray)
        {
            opponent.AgentStart();
        }
    }
}