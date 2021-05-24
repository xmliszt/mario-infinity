using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewallMover : MonoBehaviour
{
    public Canvas warning;
    public Camera mainCamera;
    private float moveSpeed = 4.0f;
    private float incrementSpeed = 0.2f;
    private Coroutine movement;

    public void StartMoving()
    {
        movement = StartCoroutine(MoveFirewall());
        InvokeRepeating("ChangeSpeed", 5, 5);
    }

    public void StopMoving()
    {
        StopCoroutine(movement);
        CancelInvoke();
    }

    public void ResetFirewall()
    {
        transform.position = new Vector3(-50, 0, 0);
    }

    IEnumerator MoveFirewall()
    {
        while (true)
        {
            if (FindObjectOfType<PlayerController>().isAlive == true)
            {
                transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
            }
            if (mainCamera.transform.position.x - transform.position.x < 5)
            {
                StartWarning();
            }
            if (transform.position.x == mainCamera.transform.position.x || mainCamera.transform.position.x > transform.position.x + 5)
            {
                StopWarning();
            }
            yield return null;
        }
    }

    private void StartWarning()
    {
        warning.GetComponent<Canvas>().enabled = true;
    }

    private void StopWarning()
    {
        warning.GetComponent<Canvas>().enabled = false;
    }

    private void ChangeSpeed()
    {
        moveSpeed += incrementSpeed;
    }
}
