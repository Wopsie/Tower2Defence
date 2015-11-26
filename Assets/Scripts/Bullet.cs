using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    [HideInInspector]     public Transform target;

	void Update () 
    {
        if(target != null)
        {
            //move bullet towards enemy
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target.position, 5f * Time.deltaTime);
        }else{
            //if no enemy is in range destroy bullet
            Destroy(gameObject);
        }

        //rotate bullet to target
        Quaternion rotation = Quaternion.LookRotation
            (target.position - transform.position, transform.TransformDirection(Vector3.up));
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