using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
    // Başlangıç sahnesinin adı
    public string startingSceneName = "Bolum1";

    private void Start()
    {
        // Bu GameObject'ı diğer sahnelerde de kullanabilmek için yok etme
        DontDestroyOnLoad(gameObject);

        // Oyuncunun son oynadığı sahneyi kontrol et
        if (!PlayerPrefs.HasKey("LastPlayedScene"))
        {
            // Eğer önceki bir sahne kaydedilmemişse, başlangıç sahnesini kullan
            PlayerPrefs.SetString("LastPlayedScene", startingSceneName);
        }
    }

    // Oyuncu bir bölümü tamamladığında çağrılacak olan metod
    public void SaveLastPlayedScene(string sceneName)
    {
        // Son oynanan sahneyi kaydet
        PlayerPrefs.SetString("LastPlayedScene", sceneName);
    }
    
    // Oyuncunun oyunu yeniden başlatmak istediğinde çağrılacak olan metod
    public void RestartGame()
    {
        // Başlangıç sahnesine geri dön
        SceneManager.LoadScene(startingSceneName);
    }
}