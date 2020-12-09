using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private GameObject camAttach;
    public AudioSource audioSource;
    public AudioClip active;
    public AudioClip death;
    public AudioClip shoot;
   


    public GameObject bullet;

    public float speed = 5.0f;
    public float health = 1.0f;
    private float second = 0.0f;
    public float minDelay = 2.0f;
    public float maxDelay = 5.0f;
    public bool canFire = true;
    public bool canMove = true;

    


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        camAttach = GameObject.Find("Main Camera");
        audioSource = camAttach.GetComponent<AudioSource>();


        

    }

    // Update is called once per frame
    void Update()
    {


        if (canMove)
        {
            rb2d.velocity = new Vector2(speed, 0);
        }
       
        if (Time.time > second) 
        {
            second += 0.01f;
        }

        if (canFire)
        {
            if (second >= Random.Range(minDelay, maxDelay))
            {
                fire();
                second = 0f;
            }
        }


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


    void fire() 
    {

        Instantiate(bullet, transform.position, transform.rotation);
        audioSource.PlayOneShot(shoot);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) 
        {
          //  Debug.Log("collided with wall");
        }
        if(collision.gameObject.layer == 9)

        {
            Debug.Log("collided with entity");
        }
        Debug.Log(collision.gameObject.layer);
        
        speed = -speed;
    }
}
