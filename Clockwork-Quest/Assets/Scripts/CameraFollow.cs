using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Oyuncunun Transform bileþeni
    public Transform player;

    // Kamera ile oyuncu arasýndaki offset (mesafe farký)
    public Vector3 offset;

    // Kamera hareket hýzýný kontrol etmek için smoothTime
    public float smoothTime = 0.3f;

    // Dahili kullaným için bir hýz vektörü
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Kameranýn hedef pozisyonunu hesapla
        Vector3 targetPosition = player.position + offset;

        // Kamerayý hedef pozisyona doðru yumuþak bir þekilde hareket ettir
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}