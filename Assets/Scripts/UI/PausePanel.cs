using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class PausePanel : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    public static bool GameIsPaused = false;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        
    }

    public void Pause()
    {
        _canvasGroup.Open();
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void Resume()
    {
        _canvasGroup.Close();
        Time.timeScale = 1;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
