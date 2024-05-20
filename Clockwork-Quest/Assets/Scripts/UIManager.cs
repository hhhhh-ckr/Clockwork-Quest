using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public int playerLive = 3;
    public List<Image> healthImages; //B�t�n can spritelerini se� ve s�r�kle
    public Text performanceScore; // Oyuncunun performans skoru
    public Text performanceText; // Oyuncunun performans yaz�s�

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoseLife()
    {
        playerLive--;
        if (playerLive > 0)
        {
            PlayerController.instance.Respawn();
        }
        else
        {
            GameManager.instance.GameOver();
        }
        UpdateLives();
    }

    public void UpdateLives()
    {
        for (int i = 0; i < healthImages.Count; i++)
        {
            if (i < playerLive)
            {
                healthImages[i].enabled = true; // Can spritesi g�ster
            }
            else
            {
                healthImages[i].enabled = false; // Can spritesi gizle
            }
        }
    }

    public void GameOverUI(int score, string comment)
    {
        if (performanceScore != null)
        {
            performanceScore.text = "Skor: " + score.ToString();
        }
        else
        {
            performanceScore = performanceScore;
        }
        
        if (performanceText != null)
        {
            performanceText.text = comment.ToString();
        }
        else
        {
            performanceText = performanceText;
        }
    }
}
