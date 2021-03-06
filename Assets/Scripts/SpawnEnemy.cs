﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour 
{
    [SerializeField]    private GameObject enemy;
    //[SerializeField] private GameObject forceField;
    protected float spawnCooldown;

    private Transform thisBase;
    [SerializeField]    private Transform straightBase;
    [SerializeField]    private Transform leftBase;
    [SerializeField]    private Transform rightBase;

    private Transform eTarget;

    private Animator anim;

    public enum Spawns
    {
        Spirit,
        Barrier
    }

    protected Dictionary<Spawns, GameObject> spawner = new Dictionary<Spawns, GameObject>();
    protected Spawns spawns;

	void Start () 
    {
        spawnCooldown = 2;
        //add objects to dictionary
        spawner.Add(Spawns.Spirit, enemy);

        //identify self
        thisBase = gameObject.transform;

        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        //pick random target
        int targeter = Random.Range(0, 3);

        //Debug.Log(gameObject + " target is: " + targeter);
        if (spawnCooldown <= 0 && targeter == 0)
        {
            //attack straight base
            eTarget = straightBase;
            Spawner();
        }
        else if (spawnCooldown <= 0 && targeter == 1)
        {
            //attack base on left
            eTarget = leftBase;
            Spawner();
        }
        else if (spawnCooldown <= 0 && targeter == 2)
        {
            //attack base on right
            eTarget = rightBase;
            Spawner();
        }
        else if (spawnCooldown <= 0 && targeter == 3)
        {
            //do nothing
            //Debug.Log("doing nothing");
        }

        //decrement spawner cooldown
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
            spawnCooldown = 0;
	}

    //spawn enemy function
    void Spawner()
    {
        spawnCooldown = 3;
        for(int i = 0; i < 5; i++)
        {
            var clone = (GameObject)Instantiate(spawner[spawns], transform.position, Quaternion.identity);
            clone.GetComponent<Enemy>().Target = eTarget;
        }
    }
}