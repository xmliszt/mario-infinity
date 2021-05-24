using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckySpawner : MonoBehaviour
{
    public Animator anim;
    public GameObject[] spawnableObjects;
    private float emitForce = 10f;
    private bool emitted = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !emitted)
        {
            emitted = true;
            int idx = Random.Range(0, spawnableObjects.Length);
            GameObject obj = spawnableObjects[idx];
            GameObject spawned = Instantiate(obj, new Vector3(transform.position.x, transform.position.y + 1.5f, 0), obj.transform.rotation);
            if (spawned.tag == "coin")
            {
                spawned.GetComponentInChildren<Animator>().SetTrigger("Emit_trig");
            } else
            {
                spawned.GetComponent<Rigidbody2D>().AddForce(Vector2.up * Time.fixedDeltaTime * emitForce * 1.5f, ForceMode2D.Impulse);
            }
            anim.SetTrigger("Emitted_trig");
            anim.SetBool("Emitted_b", true);
        }
    }
}
