using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameObject player;
    private Camera cam;
    private float upperBound = 4.0f;
    private float lowerBound = -8f;
    private float leftBound = -2.5f;
    private float smoothRate = 0.1f;
    private float offsetY = 3.0f;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.gameStarted)
        {
            float camera_y = Mathf.Clamp(player.transform.position.y, lowerBound + cam.orthographicSize, upperBound - cam.orthographicSize);
            float camera_x = Mathf.Clamp(player.transform.position.x, leftBound + cam.orthographicSize / 2, player.transform.position.x + cam.orthographicSize / 2);
            transform.position = Vector3.Lerp(transform.position, new Vector3(camera_x, camera_y + offsetY, transform.position.z), smoothRate);
        }
    }
}
