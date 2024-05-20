using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    public string StartingSceneName; // Oyunun başladığı sahne
    public string MainMenuSceneName; // Oyunun ana ekran sahnesi
    public string GameOverSceneName; // Oyuncunun kaybettiği sahne
    public string CreditsSceneName; // Oyunu yapanların olduğu sahne
    public string EndSceneName; // Oyunun bittiği sahne

    private void Start()
    {
        DontDestroyOnLoad(gameObject); // Bu GameObject'ı diğer sahnelerde de kullanabilmek için yok etme
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpışma olup olmadığını kontrol edin ve çarpışan nesnenin etiketini kontrol edin
        if (collision.gameObject.CompareTag("SceneEnder")) // Örnek olarak, eğer çarpışan nesne "Player" etiketine sahipse
        {
            SceneManager.LoadScene(EndSceneName);
        }
    }
}