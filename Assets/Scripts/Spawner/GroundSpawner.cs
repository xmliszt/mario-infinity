using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public Camera cam;
    public GameObject groundTiles;

    private Vector3 originalCamPosition;
    private float camOrthographicHalfWidth;
    private float groundY = -4.5f;
    // Start is called before the first frame update
    void Start()
    {
        camOrthographicHalfWidth = cam.orthographicSize;
        originalCamPosition = cam.transform.position;
        Spawn(cam.transform.position.x - 3.6f);
        Spawn(cam.transform.position.x + 1.5f * camOrthographicHalfWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.x - originalCamPosition.x > camOrthographicHalfWidth * 1.5f)
        {
            // Spawn right
            originalCamPosition = cam.transform.position;
            Spawn(cam.transform.position.x + 2 * camOrthographicHalfWidth);
        }
    }

    void Spawn(float x)
    {

        Instantiate(groundTiles, new Vector3(x, groundY, 0), groundTiles.transform.rotation);
    }
}
