using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Oyuncunun Transform bile�eni
    // editorden se�ilecek
    public Transform player;

    // Kamera ile oyuncu aras�ndaki offset (mesafe fark�)
    private Vector3 offset;

    void Start()
    {
        // Offset hesapla
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Kameran�n pozisyonunu g�ncelle
        transform.position = player.position + offset;
    }
}