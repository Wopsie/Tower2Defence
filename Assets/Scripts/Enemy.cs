using UnityEngine;
using System.Collections;

public class Enemy : Health
{
    public Rigidbody2D rb;

    void Start()
    {
        //Debug.Log(baseHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //move enemy down
        rb.AddForce(transform.up / -5f);
    }

    //check for collision
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Bullet")
        { 
            baseHealth--;

            if(baseHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
