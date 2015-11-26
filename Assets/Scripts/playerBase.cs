using UnityEngine;
using System.Collections;

public class playerBase : Health
{
    private float invincibility;
    

    void Start()
    {
        baseHealth = 150;
    }

    void FixedUpdate()
    {
        invincibility--;

        if(baseHealth <= 0)
        {
            Debug.Log("JE BENT HARSTIKKE DOOD");
            Application.LoadLevel(2);
        }
    }

    void Update()
    {
        invincibility -= Time.deltaTime;
        if (invincibility <= 0)
            invincibility = 0;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "SouthSpirit" && invincibility <= 0)
        {
            invincibility = 10;
            baseHealth--;
        }
        Debug.Log(baseHealth);
    }
}