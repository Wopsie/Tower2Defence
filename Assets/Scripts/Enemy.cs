using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Health
{
    public Rigidbody2D rb;
    private float speed;
    private Transform eastBase;
    private Transform westBase;
    private Transform southBase;
    private Transform northBase;

    void Start()
    {
        //Debug.Log(baseHealth);
        rb = GetComponent<Rigidbody2D>();
        baseHealth = 2;

        eastBase = GameObject.FindGameObjectWithTag("EastBase").transform;
        westBase = GameObject.FindGameObjectWithTag("WestBase").transform;
        southBase = GameObject.FindGameObjectWithTag("PlayerBase").transform;
        northBase = GameObject.FindGameObjectWithTag("NorhtBase").transform;

        southBase = southBase.GetComponent<Transform>();
        
        List<Waypoint> waypoints = new List<Waypoint>();
    }

    void Update()
    {
        Debug.Log(southBase.transform);
        //turn enemy to targeted base
        Quaternion rotation = Quaternion.LookRotation
            (southBase.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        //Move enemy
        rb.AddForce(transform.up / 5f);

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