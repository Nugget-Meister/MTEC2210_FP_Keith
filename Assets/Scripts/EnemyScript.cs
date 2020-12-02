using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public AudioSource audioSource;
    public AudioClip active;
    public AudioClip death;
    public AudioClip shoot;
   


    public GameObject bullet;

    public float speed = 5f;
    public float health = 1f;
    public float Tps = 1f;
    public float Aps = 1f;
    private float second = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource.PlayOneShot(shoot);
        Instantiate(bullet, transform.position, transform.rotation);
        bullet.SetActive(false);
        bullet.GetComponent<BulletScript>().hostile = 1;
        bullet.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
;

        if (health < 0) 
        {
            Die();
        }
    }



    public void applyDamage(float damage) 
    {
        health -= damage;
    }

    void Die() 
    {
        audioSource.PlayOneShot(death);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

            


        
}
