using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBoundFollow : MonoBehaviour
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
        if (cam.transform.position.x - cam.orthographicSize * 9 > transform.position.x)
            transform.position = new Vector3(cam.transform.position.x - 9 * cam.orthographicSize, 0, 0);
    }
}
