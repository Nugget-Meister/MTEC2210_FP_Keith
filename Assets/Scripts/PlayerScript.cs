﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb2d;
    
    public AudioSource audioSource;
    public AudioClip explosion;
    public AudioClip shoot;


    public GameObject bullet;

    public float speed = 10f;
    public float health = 1f;

    public float score = 10f;

    GameObject scoreObject;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        scoreObject = GameObject.Find("gameScore");
        

    }

    // Update is called once per frame
    void Update()
    {


        scoreObject.GetComponent<Text>().text = score.ToString();
        //

        if (health < 0){Die();}

        float horizontal = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector2(horizontal, 0f);

        fire();
    }

    private void fire() 
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Instantiate(bullet, transform.position, transform.rotation);
            audioSource.PlayOneShot(shoot);
           
            
        }
    }

    private void Die() {
        audioSource.PlayOneShot(explosion);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void applyDamage(float damage)
    {
        health -= damage;   
    }


}
