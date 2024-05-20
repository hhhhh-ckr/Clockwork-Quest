using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 1000; // Oyuncunun skoru
    public float powerUpCount = 0; // Oyuncunun power-up miktarı

    private float completionTime;
    private int damageTaken;
    private int itemsCollected;

    private UIManager uiManager;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        completionTime = 0f;
        damageTaken = 0;
        itemsCollected = 0;
        uiManager = GetComponent<UIManager>();
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
        if (Input.GetMouseButtonDown(0) && (powerUpCount != 0)) //Mouse sol tuşu basılı tutma
        {
            UsePowerUp();
        }
        else if (powerUpCount == 0)
        {
            PlayerController.instance.ResetSpeed();
        }
    }

    public void GameOver()
    {
        int performanceScore = CalculatePerformanceScore();
        string performanceComment = GetPerformanceComment(performanceScore);
        UIManager.instance.GameOverUI(performanceScore, performanceComment);
        SceneTracker.instance.LoadScene("GameOver");
    }

    public void GameFinish()
    {
        int performanceScore = CalculatePerformanceScore();
        string performanceComment = GetPerformanceComment(performanceScore);
        UIManager.instance.GameFinishUI(performanceScore, performanceComment);
        SceneTracker.instance.LoadScene("GameOver");
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
        if (score >= 700)
        {
            return "Harika iş çıkardın!";
        }
        else if (score >= 400)
        {
            return "İyi iş!";
        }
        else
        {
            return "Daha iyisini yapabilirsin!";
        }
    }


}
