using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretRange : MonoBehaviour 
{
    private bool enemyInRange;
    private int shotCooldown;
    private int spiritCount;
    [SerializeField]
    private GameObject bullet;

    public static Transform intruder;

    public enum Shooter
    {
        Bullet
    }

    public Dictionary<Shooter, GameObject> shooter = new Dictionary<Shooter, GameObject>();
    private Shooter shoot;

    void Start()
    {
        enemyInRange = false;
        shooter.Add(Shooter.Bullet, bullet);
    }

    void FixedUpdate()
    {
        shotCooldown--;
    }
    
    void OnTriggerStay2D(Collider2D coll)
    {
        enemyInRange = true;
        
        //check if enemy is in range & if turret can shoot
        if(enemyInRange = true && shotCooldown <= 0)
        {
            shotCooldown = 5;
            //spawn bullet
            var clone = (GameObject)Instantiate(shooter[shoot], transform.position, Quaternion.identity);

            intruder = coll.gameObject.transform;
        }
    }
}
