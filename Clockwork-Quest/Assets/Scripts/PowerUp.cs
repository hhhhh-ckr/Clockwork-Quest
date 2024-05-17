using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                if (gameObject.CompareTag("SlowPowerUp"))
                {
                    playerController.moveSpeed = playerController.slowSpeed;
                }
                else if (gameObject.CompareTag("FastPowerUp"))
                {
                    playerController.moveSpeed = playerController.fastSpeed;
                }

                Destroy(gameObject);
            }
        }
    }
}