using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text livesText; // Unity Editor'da atanacak

    public void UpdateLives(int lives)
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
        else
        {
            Debug.LogError("Lives Text is not assigned.");
        }
    }
}
