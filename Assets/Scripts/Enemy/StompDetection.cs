using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompDetection : MonoBehaviour
{
    public GombaMovement script;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && FindObjectOfType<PlayerController>().isAlive)
        {
            script.KillSelf();
        }
    }
}
