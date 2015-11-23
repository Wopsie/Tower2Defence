using UnityEngine;
using System.Collections;

public class SpawnTroops : SpawnEnemy {

    [SerializeField]    private GameObject spirit;

	void Start () 
    {
        spawner.Add(Spawns.Spirit, spirit);
	}

    void Update()
    {
        //spawn enemy on buttonpress
        if (DirectionButton.pTarget != null && spawnCooldown <= 0)
        {
            Spawner();
        }

        //decrement spawner cooldown
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0)
            spawnCooldown = 0;
    }

    //spawn enemy fucntion
    void Spawner()
    {
        spawnCooldown = 2;
        for (int i = 0; i < 5; i++)
        {
            var clone = (GameObject)Instantiate(spawner[spawns], transform.position, Quaternion.identity);
        }
    }
}