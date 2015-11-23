using UnityEngine;
using System.Collections;

public class Spirit : Enemy {

    private Transform playerTarget;
    private Rigidbody2D rb;

	void Awake () 
    {
        //set target
        playerTarget = DirectionButton.pTarget;
	}
	
	void Update () 
    {
        if (playerTarget != null)
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
        if (coll.gameObject.tag == "Bullet")
        {
            baseHealth--;

            if (baseHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}