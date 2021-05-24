using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTiling : MonoBehaviour
{
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.transform.position.x, 0,0);
    }
}
