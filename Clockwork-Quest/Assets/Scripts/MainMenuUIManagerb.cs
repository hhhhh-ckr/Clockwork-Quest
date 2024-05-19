using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManagerb : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Bolum1b"); 
    }


    public void ShowCredits()
    {
        SceneManager.LoadScene("CreditsScene"); 
    }
}