using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 10f;
    public float damage = 2f;
    public int hostile;


    public AudioSource audioSource;
    public AudioClip active;
    public GameObject camControl;

    // Start is called before the first frame update
    void Start()
    {
        camControl = GameObject.Find("Main Camera");
        audioSource = camControl.GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        if (hostile == 1) { speed = -speed;}
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.transform.rotation = transform.rotation;
        
        rb2d.velocity = new Vector2(0, speed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<BulletScript>().hostile == 0)
        {
            if (collision.GetComponent<EnemyScript>())
            {
                EnemyScript target = collision.GetComponent<EnemyScript>();
            //    Debug.Log("is hostile");
                Destroy(gameObject);
                target.applyDamage(damage);
                audioSource.PlayOneShot(active);

                SpriteRenderer sprite = target.GetComponentInChildren<SpriteRenderer>();
                Color color = new Color (1,1,1,0.5f);
                sprite.color = color;
                sprite.enabled = false;
                sprite.enabled = true;

            }
            else
            if (collision.GetComponent<PlayerScript>())
            {
                //PlayerScript target = collision.GetComponent<PlayerScript>();
                //Debug.Log("Is player");
                

            }
            else if (collision.gameObject.layer == 10)
            {
                //   Debug.Log("Passed bounce");
            }
            else 
            {
             //   Debug.Log("is wall");
                Destroy(gameObject);
            }
            

        }

        if (GetComponent<BulletScript>().hostile == 1)
        {
            if (collision.GetComponent<EnemyScript>())
            {
                // EnemyScript target = collision.GetComponent<EnemyScript>();
                //  Debug.Log("is hostile");
            }
            else
            if (collision.GetComponent<PlayerScript>())
            {
                PlayerScript target = collision.GetComponent<PlayerScript>();
                //    Debug.Log("Is player");
                target.applyDamage(damage);
                Destroy(gameObject);
            }
            else if (collision.gameObject.layer == 10) 
            {
             //   Debug.Log("Passed bounce");
            }
            else
            {
             //   Debug.Log("is wall");
                Destroy(gameObject);
            }
        }
    }   
}
