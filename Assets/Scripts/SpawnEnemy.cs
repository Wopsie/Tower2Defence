using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour 
{
    public GameObject enemy;
    //public GameObject forceField;
    private float spawnCooldown;

    public GameObject thisBase;
    public GameObject leftBase;
    public GameObject rightBase;
    public GameObject straightBase;

    public enum Spawns
    {
        Spirit,
        Barrier
    }

    public Dictionary<Spawns, GameObject> spawner = new Dictionary<Spawns, GameObject>();
    private Spawns spawns;

	void Start () 
    {
        //add objects to dictionary
        spawner.Add(Spawns.Spirit, enemy);
        //spawner.Add(Spawns.Barrier, forceField);

	}
	
	void Update () 
    {
        //spawn enemy on buttonpress
        if (Input.GetKeyDown(KeyCode.Space) && spawnCooldown <= 0)
        {
            Spawner();
        }
        //Debug.Log(Input.GetKey(KeyCode.Space));
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
            spawnCooldown = 0;
	}

    void Spawner()
    {
        spawnCooldown = 3;
        for(int i = 0; i < 5; i++)
        {
            var clone = (GameObject)Instantiate(spawner[spawns], transform.position, Quaternion.identity);
        }
    }
}