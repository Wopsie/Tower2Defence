using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : Health
{
	public MoneyScript moneyScript;
    private Rigidbody2D rb;
    private float speed;

    //base enemy originates from
    private GameObject owner;

    [HideInInspector]   public Transform Target;

    private SpawnEnemy spawnEnemy;
    void Start()
    {
        //identify owner
        if(gameObject.tag == "NorthEnemy")
        {
            owner = GameObject.FindGameObjectWithTag("NorthBase");
        }else if(gameObject.tag == "EastEnemy")
        {
            owner = GameObject.FindGameObjectWithTag("EastBase");
        }else if (gameObject.tag == "WestEnemy")
        {
            owner = GameObject.FindGameObjectWithTag("WestBase");
        }

        rb = GetComponent<Rigidbody2D>();
        enemyHealth = 10;
    }

    void Update()
    {
        if (Target != null)
        {
            //move enemy
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), Target.position, 2f * Time.deltaTime);

            //turn enemy to targeted base
            Quaternion rotation = Quaternion.LookRotation
                (Target.position - transform.position, transform.TransformDirection(Vector3.up));
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
            enemyHealth--;
			Debug.Log ("enemyHealth " + enemyHealth);

            if(enemyHealth == 0)
            {
				//moneyScript.AddMoney();
                Destroy(gameObject);
            }
        }
    }
}