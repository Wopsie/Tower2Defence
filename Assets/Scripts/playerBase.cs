﻿using UnityEngine;
using System.Collections;

public class playerBase : Health
{
    private int invincibility;

    void Start()
    {
        baseHealth = 50;
    }

    void FixedUpdate()
    {
        invincibility--;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Spirit" && invincibility <= 0)
        {
            //invincibility = 10;
            baseHealth--;
        }
        Debug.Log(baseHealth);
    }
}
