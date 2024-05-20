using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public int playerLive = 3;
    public List<Image> healthImages; //Bütün can spritelerini seç ve sürükle
    public Text performanceScore; // Oyuncunun performans skoru
    public Text performanceText; // Oyuncunun performans yazýsý
    public Text finishText;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoseLife()
    {
        playerLive--;
        UpdateLives();
        if (playerLive > 0)
        {
            PlayerController.instance.Respawn();
        }
        else
        {
            GameManager.instance.GameOver();
        }
    }

    public void UpdateLives()
    {
        for (int i = 0; i < healthImages.Count; i++)
        {
            if (i < playerLive)
            {
                healthImages[i].enabled = true; // Can spritesi göster
            }
            else
            {
                healthImages[i].enabled = false; // Can spritesi gizle
            }
        }
    }

    public void GameOverUI(int score, string comment)
    {
        finishText.text = "Oyun Bitti";
        performanceScore.text = "Skor: " + score.ToString();
        performanceText.text = comment.ToString();
    }

    public void GameFinishUI(int score, string comment)
    {
        finishText.text = "Kazandýn";
        performanceScore.text = "Skor: " + score.ToString();
        performanceText.text = comment.ToString();
    }
}
