using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Oyuncunun Transform bileþeni
    // editorden seçilecek
    public Transform player;

    // Kamera ile oyuncu arasýndaki offset (mesafe farký)
    private Vector3 offset;

    void Start()
    {
        // Offset hesapla
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Kameranýn pozisyonunu güncelle
        transform.position = player.position + offset;
    }
}