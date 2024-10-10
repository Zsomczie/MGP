using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp = 5;
    [SerializeField] TMP_Text Text;
    [SerializeField] GameObject player;
    private void Awake()
    {
        Text= GetComponentInChildren<TMP_Text>();
        Text.text=hp.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==6) 
        {
            if (hp>1)
            {
                Destroy(other.gameObject);
                hp--;
                Text.text = hp.ToString();
            }
            else
            {
                Destroy(other.gameObject);
                Instantiate(player, Shooting.instances[0].transform.position + (Vector3.left*2f), Quaternion.identity, Shooting.instances[0].transform);
                Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        for (int i = 0; i < Shooting.instances.Count; i++)
        {
            Shooting.instances[i].FireRate *= 0.5f;
            Shooting.instances[i].CancelInvoke();
            Shooting.instances[i].InvokeRepeating("SpawnBullet", 1, Shooting.instances[i].FireRate);
        }
    }
}
