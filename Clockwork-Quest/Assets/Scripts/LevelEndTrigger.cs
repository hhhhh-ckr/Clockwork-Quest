using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        // Geçiş animasyonunu başlat
        if (transition != null)
        {
            transition.SetTrigger("Start");
        }

        // Geçiş süresi kadar bekle
        yield return new WaitForSeconds(transitionTime);

        // Bir sonraki sahneyi yükle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}