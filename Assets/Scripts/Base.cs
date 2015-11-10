using UnityEngine;
using System.Collections;

public class Base : Health {

    private int invincibility;

	// Use this for initialization
	void Start () 
    {
        baseHealth = 50;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        invincibility--;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Spirit" && invincibility == 0)
        {
            invincibility = 10;
            baseHealth--;
        }
    }
}
