using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private Text Scoretext;
    [SerializeField] private Text Combotext;
    [SerializeField] private Text HighScoretext;
    
    private  int combo = 1;    
    private  int scorepoint;

    
    private void Awake()
    {
        instance = this;
        //Events.OnEnemyKill.AddListener(AddPoint);
    }

    private void Start()
    {        
             
        HighScoretext.text = PlayerPrefs.GetInt("Score").ToString("D8");       
    }
    public void Combo()
    {
        combo = 1;
        Combotext.text = "x" + combo.ToString();
    }
    public void AddPoint(int point)
    {
        PanelScroll.Skill++;
        scorepoint += point * combo ;
        Scoretext.text = scorepoint.ToString("D8");
        combo++;        

        if (PlayerPrefs.GetInt("Score") < scorepoint)
        {
            PlayerPrefs.SetInt("Score", scorepoint);
            HighScoretext.text = PlayerPrefs.GetInt("Score").ToString("D8");
        }
        Combotext.text = "x" + combo.ToString();
    }
    private void OnDestroy()
    {
        Events.OnEnemyKill.RemoveListener(AddPoint);
    }
}
