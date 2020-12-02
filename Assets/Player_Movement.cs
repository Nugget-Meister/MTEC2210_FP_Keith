using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb2d;
    public int speed = 10;




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector2(horizontal, 0f);

        
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            
        }
    }

    public void fire() 
    {

    }
}
