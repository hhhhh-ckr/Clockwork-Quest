using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Oyuncunun Transform bile�eni
    public Transform player;

    // Kamera ile oyuncu aras�ndaki offset (mesafe fark�)
    public Vector3 offset;

    // Kamera hareket h�z�n� kontrol etmek i�in smoothTime
    public float smoothTime = 0.3f;

    // Dahili kullan�m i�in bir h�z vekt�r�
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Kameran�n hedef pozisyonunu hesapla
        Vector3 targetPosition = player.position + offset;

        // Kameray� hedef pozisyona do�ru yumu�ak bir �ekilde hareket ettir
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}