using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    public BoxCollider2D[] colliders;
    private float moveSpeed = 2.0f;
    private bool goRight; // true: right | false: left
    private void Start()
    {
        goRight = true;
        InvokeRepeating("StartSwitching", 0, 5);
    }
    // Update is called once per frame
    void Update()
    {

        if (!goRight)
        {
            // move left
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
        else
        {
            // move right
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SwitchDirection();
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void StartSwitching()
    {
        float timeDelay = Random.Range(2.0f, 5.0f);
        Invoke("SwitchDirection", timeDelay);
    }

    private void SwitchDirection()
    {
        goRight = !goRight;
    }

}
