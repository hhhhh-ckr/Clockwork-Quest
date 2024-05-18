using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerb : MonoBehaviour
{
    public static GameManagerb instance;

    public string performanceMessage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Bu GameObject'in sahne değişimlerinde yok olmamasını sağlar
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
