using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Turret : MonoBehaviour 
{
	public MoneyScript moneyScript;
    private bool enemyInRange;
    private int shotCooldown;
    private int spiritCount;
    [SerializeField]    private GameObject bullet;

    [SerializeField]    private string friendly;

    public static Transform intruder;

    private int upgradeCount = 0;
    private int layerMask;

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
        //set layer on wich to check for enemy
        layerMask = LayerMask.GetMask("Enemy");
    }

    void Update()
    {
		Shoot();

    }

    void FixedUpdate()
    {
        shotCooldown--;
    }

    public void Shoot()
    {
        //determine turret range with overlap circle
        Collider2D turretRange = Physics2D.OverlapCircle(transform.position, 1.95f, layerMask);

        if (turretRange.gameObject.tag != friendly && turretRange != null)
        {
            enemyInRange = true;

            //check if can shoot
            if (enemyInRange = true && shotCooldown <= 0)
            {
                if (upgradeCount == 0)
                {

                    shotCooldown = 6;

                    //spawn bullet
                    var clone = (GameObject)Instantiate(shooter[shoot], transform.position, Quaternion.identity);
					moneyScript.AddMoney();
                }
                else if (upgradeCount == 1)
                {
                    shotCooldown = 5;
                    var clone = (GameObject)Instantiate(shooter[shoot], transform.position, Quaternion.identity);
                }
            }
            //determine the target
            intruder = turretRange.transform;

        }
        else
        {
            enemyInRange = false;
        }
    }

    //make turret range visible
    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, 1.95f);
    }
}