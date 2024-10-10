using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUp : MonoBehaviour
{
    //HP of powerup
    [SerializeField] int health;

    //reference to HP Text
    [SerializeField] TMP_Text healthText;

    private void Start()
    {
        //Get the reference to the text
        healthText=GetComponentInChildren<TMP_Text>();

        //sync the text to the health at the beginning of the scene
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {

            //if health is more than 1, we decrease the health
            if (health > 1)
            {
                health--;
                healthText.text = health.ToString();
                Destroy(other.gameObject);
            }

            //if health is 0, we destroy the object
            else
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        //if the object we hit is of the "Player" layer
        else if (other.gameObject.layer == 6) 
        {
            //if health is above 1, decrease it
            if (PlayerHealth.instance.playerHealth > 1)
            {
                PlayerHealth.instance.playerHealth--;

                PlayerHealth.instance.healthText.text= PlayerHealth.instance.playerHealth.ToString();

            }
            //if health is 0, kill the player and restart the scene
            else
            {
                Destroy(other.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    private void OnDestroy()
    {
        //When destroying the object, we gain more firerate
        Shooting.instance.FireRate *= 0.5f;
        Shooting.instance.CancelInvoke();
        Shooting.instance.InvokeRepeating("SpawnBullet", 1, Shooting.instance.FireRate);
    }
}
