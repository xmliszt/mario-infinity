using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject bigCloud;
    public GameObject smallCloud;
    public GameObject bigHill;
    public GameObject smallHill;
    public GameObject bigBush;
    public GameObject smallBush;

    public Camera cam;

    private int maxNumOfBigHills = 1;
    private int maxNumOfSmallHills = 2;
    private int maxNumOfBigClouds = 2;
    private int maxNumOfSmallClouds = 5;
    private int maxNumOfBigBush = 2;
    private int maxNumOfSmallBush = 3;
    private float locationYForGroundObjects = -4f; // +- 0.5f
    private float maxYForCloud = 8.0f;
    private float minYForCloud = 2.6f;
    private Vector3 originalCamPosition;
    private float camOrthographicHalfWidth;
    // Start is called before the first frame update
    void Start()
    {
        originalCamPosition = cam.transform.position;
        camOrthographicHalfWidth = 2 * cam.orthographicSize;
        SpawnAll(cam.transform.position.x - camOrthographicHalfWidth, cam.transform.position.x + camOrthographicHalfWidth);
        SpawnAll(cam.transform.position.x + camOrthographicHalfWidth, cam.transform.position.x + 3 * camOrthographicHalfWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.transform.position.x - originalCamPosition.x > camOrthographicHalfWidth * 2)
        {
            // Spawn right
            originalCamPosition = cam.transform.position;
            SpawnAll(cam.transform.position.x + camOrthographicHalfWidth, cam.transform.position.x + 3 * camOrthographicHalfWidth);
        }
    }

    // Randomly spawn background objects;
    void SpawnAll(float minX, float maxX)
    {
        int numOfBigHills = Random.Range(0, maxNumOfBigHills);
        int numOfSmallHills = Random.Range(0, maxNumOfSmallHills);
        int numOfBigClouds = Random.Range(0, maxNumOfBigClouds);
        int numOfSmallClouds = Random.Range(0, maxNumOfSmallClouds);
        int numOfBigBush = Random.Range(0, maxNumOfBigBush);
        int numOfSmallBush = Random.Range(0, maxNumOfSmallBush);

        Spawn(numOfBigHills, bigHill, minX, maxX, locationYForGroundObjects + 0.3f, locationYForGroundObjects + 0.5f);
        Spawn(numOfSmallHills, smallHill, minX, maxX, locationYForGroundObjects + 3.8f, locationYForGroundObjects + 3.8f);
        Spawn(numOfBigBush, bigBush, minX, maxX, locationYForGroundObjects, locationYForGroundObjects);
        Spawn(numOfSmallBush, smallBush, minX, maxX, locationYForGroundObjects, locationYForGroundObjects);
        Spawn(numOfBigClouds, bigCloud, minX, maxX, minYForCloud, maxYForCloud);
        Spawn(numOfSmallClouds, smallCloud, minX, maxX, minYForCloud, maxYForCloud);
    }

    void Spawn(int num, GameObject obj, float minX, float maxX, float minY, float maxY, float z=0)
    {
        for (int i = 0; i < num; i ++)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);
            Instantiate(obj, new Vector3(x, y, z), obj.transform.rotation);
        }
    }
}
