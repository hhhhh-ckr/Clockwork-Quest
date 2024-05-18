using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollision : MonoBehaviour
{
    public string targetSceneName; // Geçmek istediğiniz hedef sahne adı

    private void OnCollisionEnter(Collision collision)
    {
        // Çarpışma olup olmadığını kontrol edin ve çarpışan nesnenin etiketini kontrol edin
        if (collision.gameObject.CompareTag("Son")) // Örnek olarak, eğer çarpışan nesne "Player" etiketine sahipse
        {
            // Hedef sahneye geçiş yap
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
