using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinsibleKillDetection : MonoBehaviour
{
    public GombaMovement script;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && FindObjectOfType<PlayerController>().isInvinsible)
        {
            script.KillSelf();
        }
    }
}
