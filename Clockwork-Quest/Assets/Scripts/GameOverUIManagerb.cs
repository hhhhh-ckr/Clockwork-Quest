using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManagerb : MonoBehaviour
{
    public Text performanceText;

    private void Start()
    {
        if (GameManagerb.instance != null)
        {
            performanceText.text = GameManagerb.instance.performanceMessage; // Mesajı UI Text'e yazdır
        }
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenub"); 
    }
}
