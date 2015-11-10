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

        //rotate bullet to intruder
        Quaternion rotation = Quaternion.LookRotation
            (Turret.intruder.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        //check for collision
        if(coll.gameObject.tag == "Spirit")
        {
            Destroy(gameObject);
        }
    }
}