using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GombaMovement : MonoBehaviour
{
    public Collider2D[] colliders;
    private float moveSpeed = 2.0f;
    private bool goRight; // true: right | false: left
    public Animator anim;
    public bool dead;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        goRight = true;
        dead = false;
        InvokeRepeating("StartSwitching", 0, 5);
    }
    // Update is called once per frame
    void Update()
    {
        if (!dead)
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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SwitchDirection();
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

    public void KillSelf()
    {
        dead = true;
        OffAllColliders();
        anim.SetTrigger("Dead_trig");
        Invoke("SelfDestroy", 1.0f);
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void OffAllColliders()
    {
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
