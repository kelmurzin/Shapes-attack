using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerhealth;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private PanelLose _panellose;
    [SerializeField] private SoundManager soundManager;
    public void OnEnable()
    {
        _playerhealth.OnDie += Gameover;       
    }

    public void Gameover()
    {
         _panellose.Open();
        // LosePanel.SetActive(true);
        if (soundManager.muted == false)
        {
            //soundManager.muted = true;
            soundManager.shoot.mute = true;
        }
        if (soundManager.musmuted == false)
        {

            soundManager.music.mute = true;
            soundManager.bomb.mute = true;
        }
        Time.timeScale = 0f;
    }

    public void PanelClose()
    {
        //LosePanel.SetActive(false);
    }
    public void OnDisable()
    {
        _playerhealth.OnDie -= Gameover;        
    }
}
