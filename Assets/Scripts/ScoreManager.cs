using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI nowScoreUI;
    public int nowScore;
    public TextMeshProUGUI bestScoreUI;
    public int bestScore;

    private void Start()
    {
        nowScore = PlayerPrefs.GetInt("NowScore", 0);
        nowScoreUI.text = "Now Score : " + nowScore;

        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreUI.text = "Best Score : " + bestScore;
    }
    
}
