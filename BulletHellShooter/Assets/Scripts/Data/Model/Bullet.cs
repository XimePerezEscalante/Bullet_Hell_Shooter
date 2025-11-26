using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed;
    public Quaternion rotation;
    public float fireRate;
    public bool isAttacking;
    // Puede ser lineal o circular
    public int Type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
