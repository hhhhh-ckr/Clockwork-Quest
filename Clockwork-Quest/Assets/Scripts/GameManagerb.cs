using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerb : MonoBehaviour
{
    public static GameManagerb instance;

    // Oyuncunun power-up miktarı
    public float powerUpCount = 0;

    // Oyuncunun performans yazısı
    public string performanceMessage;
    public int performanceScore;

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

    // Power-up kullanım takip
    public void AddPowerUp()
    {
        powerUpCount += 3f;
    }

    public void UsePowerUp()
    {
        if (PlayerControllerb.instance != null)
        {
            PlayerControllerb.instance.moveSpeed = 7f;  // Oyuncunun hızını ayarla
        }

        float deltaTime = Time.deltaTime;  // Son frame'den bu yana geçen zaman
        powerUpCount -= deltaTime;  // Power-up miktarını azalt
        if (powerUpCount < 0) powerUpCount = 0;  // Power-up miktarını negatif yapma
    }
}
