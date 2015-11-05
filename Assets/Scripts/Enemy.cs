using UnityEngine;
using System.Collections;

public class Enemy : Health
{

    public Rigidbody2D rb;
    void Start()
    {
        Debug.Log(baseHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce(transform.up / -5f);
    }

    void OnCollisionEnter(Collision coll)
    {
       baseHealth = baseHealth - 1;
       Destroy(this.gameObject);
       Debug.Log("Enemie.cs: " + baseHealth);
    }
}
