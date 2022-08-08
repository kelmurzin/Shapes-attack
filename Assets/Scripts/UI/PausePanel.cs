using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class PausePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    [SerializeField] private GameManager gameManager;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        gameManager.onBoolChange += GameActive;
    }

    private void OnDestroy() => gameManager.onBoolChange -= GameActive;
    
    private void GameActive(bool isActive)
    {
        if (isActive)
            Pause();
        else
            Resume();           
    }

    private void Pause()
    {
        _canvasGroup.Open();
        Time.timeScale = 0;    
    }

    private void Resume()
    {
        _canvasGroup.Close();
        Time.timeScale = 1;      
    }
}
