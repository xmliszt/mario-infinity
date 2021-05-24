using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numOfSpawnPerView;
    public int scoreToSpawnFirepipe;
    public Camera cam;
    public GameObject enemy;
    public GameObject firepipe;

    private Vector3 originalCamPosition;
    private float camOrthographicHalfWidth;
    private float spawnY = -3;
    // Start is called before the first frame update
    void Start()
    {
        camOrthographicHalfWidth = cam.orthographicSize;
        originalCamPosition = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.x - originalCamPosition.x > camOrthographicHalfWidth * 2)
        {
            // Spawn right
            originalCamPosition = cam.transform.position;
            Spawn(cam.transform.position.x + 3 * camOrthographicHalfWidth, enemy);
            if (FindObjectOfType<ScoreManager>().GetScore() >= scoreToSpawnFirepipe)
            {
                if (Random.Range(1, 999) % 3 == 0)
                {
                    Spawn(cam.transform.position.x + 3 * camOrthographicHalfWidth, firepipe);
                }
            }
        }
    }

    private void Spawn(float x, GameObject obj)
    {
        for (int i = 0; i < numOfSpawnPerView; i ++)
        {
            Instantiate(obj, new Vector3(x, spawnY, 0), enemy.transform.rotation);
        }
    }
}
