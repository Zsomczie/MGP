using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

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
                //we damage the player, a.k.a. decrease health by 1
                health--;

                //display the health as text
                healthText.text = health.ToString();

                //destroy the bullet when it hits the enemy
                Destroy(other.gameObject);

                //Getting the material of the enemy and creating a new sequence
                var mat = transform.GetComponent<MeshRenderer>().material;
                Sequence mySequence = DOTween.Sequence();

                //adding functions to the sequence
                mySequence
                    .Append(transform.DOPunchPosition(Vector3.forward, 0.5f, 2))
                    .Insert(0, mat.DOColor(Color.red, 0.5f))
                    .Append(mat.DOColor(Color.yellow, 0.5f));
                

                
                //Camera.main.transform.DOPunchPosition(Vector3.down, 1f, 5);
            }

            //if health is 0, we destroy the object
            else
            {
                
                Destroy(other.gameObject);

                //Before destroying the object, scale it down to 0 under 0.5 seconds
                transform.DOScale(0f, 0.5f).OnComplete(()=> Destroy(gameObject));
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
        //getting the material of the player, and changing to a random color with DOTween 
        var mat = Shooting.instance.gameObject.GetComponent<MeshRenderer>().material;
        mat.DOColor(Random.ColorHSV(), 0.2f);

        //When destroying the object, we gain more firerate
        Shooting.instance.FireRate *= 0.5f;
        Shooting.instance.CancelInvoke();
        Shooting.instance.InvokeRepeating("SpawnBullet", 1, Shooting.instance.FireRate);

        //Killing all DOTween functions, so they don't take performance
        transform.DOKill();
    }
}
