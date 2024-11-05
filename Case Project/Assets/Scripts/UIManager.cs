using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject _startPanel;
    
    public void TapToStart()
    {
        _startPanel.SetActive(false);
    }
}
