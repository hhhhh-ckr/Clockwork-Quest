using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeveLoader : MonoBehaviour
{
    public Animator transition; // Sahne geçiş efekti için Animator bileşeni
    public float transitionTime = 1f; // Geçiş efektinin süresi

    private void OnTriggerEnter(Collider other)
    {
        // Eğer temas eden nesne "Player" ise
        if (other.CompareTag("Son"))
        {
            LoadNextLevel(); // Sahneyi değiştir
        }
    }

    // Bir sonraki sahneyi yüklemek için kullanılacak fonksiyon
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); // Bir sonraki sahneyi yükle
    }

    // Geçiş efekti ve sahne yükleme işlemlerini gerçekleştiren coroutine
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start"); // Geçiş efektini başlat

        yield return new WaitForSeconds(transitionTime); // Belirli bir süre bekle

        SceneManager.LoadScene(levelIndex); // Belirtilen sahneyi yükle
    }
}
