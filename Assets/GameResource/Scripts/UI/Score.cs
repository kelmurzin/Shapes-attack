using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Score : MonoBehaviour
{
    public static Score instance;
    public event Action<int> onScoreChange = delegate { };
    public event Action<int> onComboChange = delegate { };
    public event Action onHighScoreChange = delegate { };
 
    private  int combo = 1;    
    private  int scorepoint;
    
    private void Awake()
    {
        if (instance == null)
        {
           instance = this;
            return;
        }
        Destroy(this.gameObject);
    }

    private void Start() => onHighScoreChange();


    public void Combo()
    {
        combo = 1;
        onComboChange(combo);
    }

    public void AddPoint(int point)
    {
        PanelScroll.Skill++;
        scorepoint += point * combo ;
        onScoreChange(scorepoint);
        combo++;        

        if (PlayerPrefs.GetInt("Score") < scorepoint)
        {
            PlayerPrefs.SetInt("Score", scorepoint);   
            onHighScoreChange();
        }
        
        onComboChange(combo);
    }
    
}
