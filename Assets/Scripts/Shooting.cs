using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] public float FireRate;
    public static List<Shooting> instances;

    private void Awake()
    {
        if (instances == null) 
        { 
            instances = new List<Shooting>(); 
        }
        instances.Add(this);
    }
    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("SpawnBullet", 1, FireRate);
    }
    void SpawnBullet() 
    {
        Instantiate(bullet,transform.position,transform.rotation);
    }
}
