using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour 
{
    private bool enemyInRange;
    private int shotCooldown;
    private int spiritCount;
    [SerializeField]
    private GameObject bullet;

    //public Collider2D turretRange;

    public static Transform intruder;

    private int upgradeCount = 0;

    public enum Projectile
    {
        Bullet
    }

    public Dictionary<Projectile, GameObject> shooter = new Dictionary<Projectile, GameObject>();
    private Projectile shoot;

    void Start()
    {
        enemyInRange = false;
        shooter.Add(Projectile.Bullet, bullet);
    }

    void Update()
    {
        //establish turret range
        Collider2D turretRange = Physics2D.OverlapCircle(transform.position, 1.6f);

        //check if enemy is in range
        if (turretRange.gameObject.tag == "Spirit")
        {
            enemyInRange = true;
            
            //check if can shoot
            if (enemyInRange = true && shotCooldown <= 0)
            {
                if (upgradeCount == 0)
                {
                    shotCooldown = 8;

                    //spawn bullet
                    var clone = (GameObject)Instantiate(shooter[shoot], transform.position, Quaternion.identity);
                }
                else if (upgradeCount == 1)
                {
                    shotCooldown = 5;
                    var clone = (GameObject)Instantiate(shooter[shoot], transform.position, Quaternion.identity);
                }
            }
            intruder = turretRange.transform;
        }
    }

    void FixedUpdate()
    {
        shotCooldown--;
    }
    
    void OnTriggerStay2D(Collider2D coll)
    {
        /*
        intruder = coll.gameObject.transform;
        */
    }

    void Upgrader()
    {
        upgradeCount++;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, 1.6f);
    }
}