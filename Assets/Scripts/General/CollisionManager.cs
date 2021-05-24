using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public Animator anim;

    private Collider2D collider_2d;
    private void Start()
    {
        collider_2d = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collider_2d.tag)
        {
            case "bumper":
                anim.SetTrigger("Bumped_trig");
                break;
            default:
                break;
        }
    }
}
