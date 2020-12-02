using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 10f;
    public float damage = 2f;
    public int hostile;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<BulletScript>().hostile == 0)
        {
            if (collision.GetComponent<EnemyScript>())
            {
                EnemyScript target = collision.GetComponent<EnemyScript>();
                Debug.Log("is hostile");
                Destroy(gameObject);
                target.applyDamage(damage);

            }
            else
            if (collision.GetComponent<PlayerScript>())
            {
                //PlayerScript target = collision.GetComponent<PlayerScript>();
                //Debug.Log("Is player");
                

            }
            else 
            {
                Debug.Log("is wall");
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
                Debug.Log("Is player");
                target.applyDamage(damage);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("is wall");
                Destroy(gameObject);
            }
        }
    }   
}
