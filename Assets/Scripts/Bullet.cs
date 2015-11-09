using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void Update () 
    {
        if(Turret.intruder != null)
        {
            //move bullet towards enemy
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), Turret.intruder.position, 5f * Time.deltaTime);
        }else{
            //if no enemy is in range destroy bullet
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //check for collision
        if(coll.gameObject.tag == "Spirit")
        {
            Destroy(gameObject);
        }

        Debug.Log(coll.gameObject.tag);
    }
}