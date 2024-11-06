using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject _startPanel;
    private Opponents[] _opponentsArray;
    public TextMeshProUGUI coinCountText, deadCounText;

    private void Start()
    {
        _opponentsArray = FindObjectsOfType<Opponents>();
    }

    public void TapToStart()
    {
        _startPanel.SetActive(false);

        foreach (var opponent in _opponentsArray)
        {
            opponent.AgentStart();
        }
    }
}