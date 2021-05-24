using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObjects : MonoBehaviour
{
    public GameObject objectToFire;
    private float fireRate = 1.0f; // seconds
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0, fireRate);
    }

    private void Fire()
    {
        Instantiate(objectToFire, gameObject.transform, false);
    }
}
