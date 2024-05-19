using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControllerb playerController = collision.gameObject.GetComponent<PlayerControllerb>();
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