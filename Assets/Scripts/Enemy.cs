﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Health
{
    private Rigidbody2D rb;
    protected float speed;

    //base transforms
    protected Transform eastBase;
    protected Transform westBase;
    protected Transform southBase;
    protected Transform northBase;

    private Transform playerTarget;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseHealth = 2;

        eastBase = GameObject.FindGameObjectWithTag("EastBase").transform;
        westBase = GameObject.FindGameObjectWithTag("WestBase").transform;
        southBase = GameObject.FindGameObjectWithTag("PlayerBase").transform;
        northBase = GameObject.FindGameObjectWithTag("NorthBase").transform;  
    }

    void Awake()
    {
        playerTarget = DirectionButton.pTarget;
    }

    void Update()
    {
        if(playerTarget != null)
        {
            //move enemy
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), playerTarget.position, 2f * Time.deltaTime);

            //turn enemy to targeted base
            Quaternion rotation = Quaternion.LookRotation
                (playerTarget.position - transform.position, transform.TransformDirection(Vector3.up));
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