using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int coinCount;
    UIManager _uiManager;
    GameManager _gameManager;

    private void Awake()
    {
        _uiManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        coinCount = 0;
    }
    public void UpdateStarScore()
    {
        _uiManager.coinCountText.text = coinCount.ToString();
    }


}
