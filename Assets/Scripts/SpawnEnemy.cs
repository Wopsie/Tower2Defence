using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour 
{
    public GameObject enemy;
    public GameObject forceField;
    private int i;

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
        spawner.Add(Spawns.Barrier, forceField);
	}
	
	void Update () 
    {
        //spawn enemy on buttonpress
        if(Input.GetKey(KeyCode.Space))
        {
            i++;
            Spawner();
        }
	}

    void Spawner()
    {
        //if(i <= 15)
        //{
            Debug.Log(i);
            var clone = (GameObject)Instantiate(spawner[spawns], transform.position, Quaternion.identity);
        //}
    }
}