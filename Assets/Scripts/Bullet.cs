using UnityEngine;
using System.Collections;

public class Bullet : TurretRange {

	void Update () 
    {
        //moves bullet towards the intruder
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), intruder.position, 5f * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Spirit")
        {
            Destroy(gameObject);
            Debug.Log("destroy bullet");
        } 
    }
}
