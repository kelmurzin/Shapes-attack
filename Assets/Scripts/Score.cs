using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TMP_Text Scoretext;
    [SerializeField] private TMP_Text Combotext;
    [SerializeField] private TMP_Text HighScoretext;
    
    private  int combo = 1;    
    private  int scorepoint;

    
    private void Awake()
    {
        instance = this;
        
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
    
}
