using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManagerb : MonoBehaviour
{
    public Text performanceText;
    
    public PerformanceEvaluatorb performanceEvaluator;
    public Text scoreText;

    private void Start()
    {
        if (GameManagerb.instance != null)
        {
            performanceText.text = GameManagerb.instance.performanceMessage;
            scoreText.text = "Score: " + GameManagerb.instance.performanceScore.ToString();
        }
        
        // Performansı değerlendir ve sonucu göster
        ShowPerformance();
    }
    
    public void ShowPerformance()
    {
        int performanceScore = performanceEvaluator.CalculatePerformanceScore();
        string performanceComment = performanceEvaluator.GetPerformanceComment(performanceScore);
        performanceText.text = performanceComment;
    }

    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenub"); 
    }
}
