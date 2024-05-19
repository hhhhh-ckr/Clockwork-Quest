using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // UIManager kullanarak metni gösterebilmek için

public class PerformanceEvaluatorb : MonoBehaviour
{
    public Text performanceText; // Performans yorumunu göstermek için
    public float completionTime;
    public int damageTaken;
    public int itemsCollected;

    private void Start()
    {
        // Oyunun başında sıfırlama
        completionTime = 0f;
        damageTaken = 0;
        itemsCollected = 0;
    }

    private void Update()
    {
        // Zamanı güncelle
        completionTime += Time.deltaTime;
    }

    public void RecordDamage(int damage)
    {
        damageTaken += damage;
    }

    public void RecordItemCollected()
    {
        itemsCollected++;
    }

    public void EvaluatePerformance()
    {
        int performanceScore = CalculatePerformanceScore();
        string performanceComment = GetPerformanceComment(performanceScore);
        performanceText.text = performanceComment;
    }

    public int CalculatePerformanceScore()
    {
        // Performans puanını hesaplamak için basit bir örnek:
        int score = 100;

        score -= (int)completionTime; // Zaman arttıkça puan azalsın
        score -= damageTaken * 10; // Alınan hasar puanı azaltsın
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