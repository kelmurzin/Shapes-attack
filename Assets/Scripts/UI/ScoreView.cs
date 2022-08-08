using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text Scoretext;
    [SerializeField] private TMP_Text Combotext;
    [SerializeField] private TMP_Text HighScoretext;
    [SerializeField] private Score score;

    private void Start()
    {  
        score.onComboChange += UpdateTextCombo;
        score.onScoreChange += UpdateTextScore;
        score.onHighScoreChange += UpdateHighScoreText;
    }
    private void OnDestroy()
    {
        score.onComboChange -= UpdateTextCombo;
        score.onScoreChange -= UpdateTextScore;
        score.onHighScoreChange -= UpdateHighScoreText;
    }

    private void UpdateTextScore(int scorePoint) => Scoretext.text = scorePoint.ToString("D8");
    
    private void UpdateTextCombo(int combo) => Combotext.text = "x" + combo.ToString();
    
    private void UpdateHighScoreText() => HighScoretext.text = PlayerPrefs.GetInt("Score").ToString("D8");
    
}
