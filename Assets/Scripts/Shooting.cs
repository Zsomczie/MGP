using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] public float FireRate;
    public static Shooting instance;

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = this; 
        }
        else
        {
            Destroy(this);
        }
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
