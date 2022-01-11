using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerhealth;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private PanelLose _panellose;
    
    public void OnEnable()
    {
        _playerhealth.OnDie += Gameover;       
    }
    public void Gameover()
    {       
        _panellose.Open();
        Time.timeScale = 0f;
    }
    public void OnDisable()
    {
        _playerhealth.OnDie -= Gameover;        
    }
}
