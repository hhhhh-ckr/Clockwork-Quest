using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; 

    public Text livesText; 

    // private void Awake()
    // {
    //
    //     if (instance == null)
    //     {
    //         instance = this;
    //     }
    //     else
    //     {
    //         Destroy(gameObject); 
    //     }
    // }


    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives; 
    }
}
