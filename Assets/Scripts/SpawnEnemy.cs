using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour 
{
    [SerializeField]    private GameObject enemy;
    //[SerializeField] private GameObject forceField;
    protected float spawnCooldown;

    private int spawnerID;

    private Transform thisBase;

    public static Transform eTarget;

    public enum Spawns
    {
        Spirit,
        Barrier
    }

    protected Dictionary<Spawns, GameObject> spawner = new Dictionary<Spawns, GameObject>();
    protected Spawns spawns;

	void Start () 
    {
        //add objects to dictionary
        spawner.Add(Spawns.Spirit, enemy);
        //spawner.Add(Spawns.Barrier, forceField);

        //identify object
        switch(gameObject.tag)
        {
            case "EastSpawn":
                spawnerID = 1;
                break;
            case "WestSpawn":
                spawnerID = 2;
                break;
            case "NorthSpawn":
                spawnerID = 3;
                break;
            case "SouthSpawn":
                spawnerID = 4;
                break;
        }
	}
	
	void Update ()
    {
        float randomTarget = Random.Range(0f, 3f);

        if(spawnCooldown <= 0 && randomTarget == 0f)
        {
            //attack straight base
        }else if(spawnCooldown <= 0 && randomTarget == 1f)
        {
            //attack base on left
        }else if(spawnCooldown <= 0 && randomTarget == 2f)
        {
            //attack base on right
        }else if(spawnCooldown <= 0 && randomTarget == 3f)
        {
            //do nothing
        }

        float randomSpawn = Random.Range(0f, 1f);

        //spawn enemy on buttonpress
        if (spawnCooldown <= 0 && randomSpawn == 1)
        {
            Spawner();
        }
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
            spawnCooldown = 0;
	}

    //spawn enemy fucntion
    void Spawner()
    {
        spawnCooldown = 2;
        for(int i = 0; i < 5; i++)
        {
            var clone = (GameObject)Instantiate(spawner[spawns], transform.position, Quaternion.identity);
        }
    }
}