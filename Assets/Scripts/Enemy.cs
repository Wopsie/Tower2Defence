﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Health
{
    private Rigidbody2D rb;
    private float speed;

    //base enemy originates from
    private GameObject owner;

    [HideInInspector]   public Transform Target;

    private Animator anim;

    private SpawnEnemy spawnEnemy;
    void Start()
    {
        anim = GetComponent<Animator>();

        //identify owner
        if(gameObject.tag == "NorthEnemy")
        {
            owner = GameObject.FindGameObjectWithTag("NorthBase");
        }else if(gameObject.tag == "EastEnemy")
        {
            owner = GameObject.FindGameObjectWithTag("EastBase");
        }else if (gameObject.tag == "WestEnemy")
        {
            owner = GameObject.FindGameObjectWithTag("WestBase");
        }

        rb = GetComponent<Rigidbody2D>();
        baseHealth = 8;
    }

    void Update()
    {
        if (Target != null)
        {
            //move enemy
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), Target.position, 2f * Time.deltaTime);

            //turn enemy to targeted base
            Quaternion rotation = Quaternion.LookRotation
                (Target.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
        else
        {
            Destroy(gameObject);
        }
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