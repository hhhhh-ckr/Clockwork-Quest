using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public List<Image> healthImages; //Bütün can spritelerini seç ve sürükle
    public Text performanceScore; // Oyuncunun performans skoru
    public Text performanceText; // Oyuncunun performans yazýsý

    public void UpdateLives(int lives)
    {
        int playerLive = GameManager.instance.playerLive;
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
        
    }
}
