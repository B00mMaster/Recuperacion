using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    public TextMeshProUGUI timerText;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Instance");
        }

        Instance = this;
        
        // Suscribir un método al evento OnHighScoreChange
        Score.OnHighScoreChange += Score_OnHighScoreChange;
    }

    private void OnDisable()
    {
        Score.OnHighScoreChange -= Score_OnHighScoreChange;
    }

    private void Score_OnHighScoreChange(object sender, EventArgs e)
    {
        UpdateHighScoreText();
    }

    public void UpdateHighScoreText()
    {
        int highScore = Score.GetHighScore();
        highScoreText.text = highScore.ToString();
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public IEnumerator Countdown()
    {
        int count = 5;

        while(count>=0)
        {
            Debug.Log("PU_ON");
            timerText.text=count.ToString();
            
            yield return new WaitForSeconds(1f);
            count--;

        }

    }
}
