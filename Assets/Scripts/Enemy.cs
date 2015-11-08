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
        rb.AddForce(transform.up / -5f);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        Debug.Log("collision happes");
        //Debug.Log("Enemie.cs: " + baseHealth);
        
        if(coll.gameObject.tag == "Bullet")
        { 
            baseHealth--;
            Debug.Log("getting shot");

            if(baseHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
