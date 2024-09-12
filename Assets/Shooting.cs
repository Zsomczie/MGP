using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    void Start()
    {
        InvokeRepeating("BulletSpawn", 0, fireRate);
    }
    void BulletSpawn() 
    {
        Instantiate(bullet,transform.position,transform.rotation);
    }
}
