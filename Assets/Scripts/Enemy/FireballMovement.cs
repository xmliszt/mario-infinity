using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    private float moveSpeed = 10;
    private float boundaryY = 20;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > boundaryY)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
