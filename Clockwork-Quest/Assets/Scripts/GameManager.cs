using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerLive = 3; // Oyuncunun can miktarı
    public int score = 1000; // Oyuncunun skoru
    public float powerUpCount = 0; // Oyuncunun power-up miktarı

    private float completionTime;
    private int damageTaken;
    private int itemsCollected;

    private UIManager uiManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Bu GameObject'in sahne değişimlerinde yok olmamasını sağlar
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        completionTime = 0f;
        damageTaken = 0;
        itemsCollected = 0;
        uiManager.UpdateLives(playerLive);
    }

    private void Update()
    {
        completionTime += Time.deltaTime; //Tamamlama zamanı
        LeftMouseClick();
    }

    public void Damage(int damage)
    {
        damageTaken += damage; //Alınan hasar
    }

    public void LoseLife()
    {
        playerLive--;
        uiManager.UpdateLives(playerLive);

        if (playerLive <= 0)
        {
            GameOver();
        }
        else
        {
            PlayerController.instance.Respawn();
        }
    }

    private void GameOver()
    {
        EvaluatePerformance();
        SceneManager.LoadScene("GameOverb");
    }

    public void ItemCollected()
    {
        itemsCollected++;
    }

    public void AddPowerUp()
    {
        powerUpCount += 3f;
    }

    public void UsePowerUp()
    {
        if (PlayerController.instance != null)
        {
            PlayerController.instance.moveSpeed = 7f;  // Oyuncunun hızını ayarla
        }

        float deltaTime = Time.deltaTime;  // Son frame'den bu yana geçen zaman
        powerUpCount -= deltaTime;  // Power-up miktarını azalt
        if (powerUpCount < 0) powerUpCount = 0;  // Power-up miktarını negatif yapma
    }
    public void LeftMouseClick()
    {
        if (Input.GetMouseButton(0) && (powerUpCount != 0)) //Mouse sol tuşu basılı tutma
        {
            UsePowerUp();
        }
        else
        {
            PlayerController.instance.ResetSpeed();
        }
    }

    public void EvaluatePerformance()
    {
        int performanceScore = CalculatePerformanceScore();
        string performanceComment = GetPerformanceComment(performanceScore);
        UIManager.instance.GameOverUI(performanceScore, performanceComment);
    }

    public int CalculatePerformanceScore()
    {
        score -= (int)completionTime; // Zaman arttıkça, puan azalsın
        score -= damageTaken; // Alınan hasar, puanı azaltsın
        score += itemsCollected * 5; // Toplanan öğeler puanı arttırsın

        return score;
    }

    public string GetPerformanceComment(int score)
    {
        if (score >= 80)
        {
            return "Harika iş çıkardın! Zamanın bile senin hızına yetişemedi!";
        }
        else if (score >= 50)
        {
            return "İyi iş! Ama daha hızlı olabilirdin!";
        }
        else
        {
            return "Daha iyisini yapabilirsin! Sanki zaman seni geçti gibi!";
        }
    }


}
