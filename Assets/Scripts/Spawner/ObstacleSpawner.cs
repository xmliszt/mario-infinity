using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Randomly spawn a number of sky brick at random reacheable locations
// Randomly spawn a number of lucky boxes, will always at the side of sky bricks
// Detect camera's boundary, once past the boundary, will spawn new objects
public class ObstacleSpawner : MonoBehaviour
{
    public int maxNumOfBricks;        // per generation
    public int maxNumOfLuckyBoxes;    // per generation
    public GameObject skyBrick;
    public GameObject luckyBoxBrick;
    public GameObject coin;
    public Camera cam;

    private float minYSpawnLocation = -1.0f;   // cannot spawn below this value
    private float maxYSpawnLocation = 1.5f; // cannot spawn above this value
    private Vector3 originalCamPosition;
    private float camOrthographicHalfWidth;
    private float brickWidth;

    private void Start()
    {
        originalCamPosition = cam.transform.position;
        camOrthographicHalfWidth = cam.orthographicSize * 2;
        BoxCollider2D collider = skyBrick.GetComponentInChildren<BoxCollider2D>();
        brickWidth = collider.size.x;
        SpawnObstacles(cam.transform.position.x + camOrthographicHalfWidth, cam.transform.position.x + 3 * camOrthographicHalfWidth);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(string.Format("{0} - {1} <=> {2}", cam.transform.position.x, originalCamPosition.x, camOrthographicWidth));
        if (cam.transform.position.x - originalCamPosition.x >= camOrthographicHalfWidth * 2)
        {
            // Generate on the right
            originalCamPosition = cam.transform.position;

            SpawnObstacles(cam.transform.position.x + camOrthographicHalfWidth, cam.transform.position.x + 3 * camOrthographicHalfWidth);
        }
    }

    // Randomly spawn sky bricks with lucky boxes within the range
    void SpawnObstacles(float minX, float maxX)
    {
        int numOfBricks = Random.Range(2, maxNumOfBricks+1);
        int numOfLuckyBoxs = Random.Range(0, maxNumOfLuckyBoxes+1);

        // Get the location of first spawn point
        float spawnX = Random.Range(minX, maxX);
        float spawnY = Random.Range(minYSpawnLocation, maxYSpawnLocation);
        Vector3 spawnPoint = new Vector3(spawnX, spawnY, 0);

        GameObject[] tileList = new GameObject[numOfBricks];
        // Get the index location of the lucky box
        for (int i = 0; i < numOfLuckyBoxs; i ++)
        {
            int spawnIdx = Random.Range(0, numOfBricks);
            tileList[spawnIdx] = Instantiate(luckyBoxBrick, spawnPoint + new Vector3(brickWidth * spawnIdx, 0, 0), luckyBoxBrick.transform.rotation);
        }
        // Fill in normal sky box to the rest of positions
        for (int i = 0; i < numOfBricks; i ++)
        {
            if (tileList[i] == null)
            {
                tileList[i] = Instantiate(skyBrick, spawnPoint + new Vector3(brickWidth * i, 0, 0), skyBrick.transform.rotation);
            }
        }

        int coinIdx = Random.Range(0, numOfBricks);
        Instantiate(coin, spawnPoint + new Vector3(brickWidth * coinIdx, 1.3f, 0), skyBrick.transform.rotation);

    }
}
