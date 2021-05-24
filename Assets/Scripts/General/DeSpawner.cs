using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawner : MonoBehaviour
{
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < cam.transform.position.x - 10*cam.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
