using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    public static SceneTracker instance;

    public string StartingSceneName; // Oyunun başladığı sahne
    public string MainMenuSceneName; // Oyunun ana ekran sahnesi
    public string GameOverSceneName; // Oyuncunun kaybettiği sahne
    public string CreditsSceneName; // Oyunu yapanların olduğu sahne
    public string EndSceneName; // Oyunun bittiği sahne

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadScene(string name)
    {
        if (name == "Bolum1")
        {
            SceneManager.LoadScene(StartingSceneName);
        }
        else if (name == "MainMenu")
        {
            SceneManager.LoadScene(MainMenuSceneName);
        }
        else if (name == "GameOver")
        {
            SceneManager.LoadScene(GameOverSceneName);
        }
        else if (name == "Credits")
        {
            SceneManager.LoadScene(CreditsSceneName);
        }
        else if (name == "End")
        {
            SceneManager.LoadScene(EndSceneName);
        }
    }
}