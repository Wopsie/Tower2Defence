using UnityEngine;
using System.Collections;

public class playerBase : Health
{
    private int invincibility;

    void Start()
    {
        baseHealth = 500;
    }

    void FixedUpdate()
    {
        invincibility--;

        if(baseHealth <= 0)
        {
            Debug.Log("JE BENT HARSTIKKE DOOD");
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Spirit" && invincibility <= 0)
        {
            //invincibility = 10;
            baseHealth--;
        }
        //Debug.Log(baseHealth);
    }
}