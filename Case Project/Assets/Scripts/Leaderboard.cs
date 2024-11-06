using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI[] rankTexts;

    public string[] playerNames = { "P1", "P2", "P3", "P4", "P5", "P6", "P7", "P8", "P9", "P10", "P11" }; 

    void Update()
    {
        for (int i = 0; i < rankTexts.Length && i < playerNames.Length; i++)
        {
            rankTexts[i].text = playerNames[i];
        }
    }
}