using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerBase : Health
{
    private float invincibility;

    [SerializeField]    private GameObject healthText;
    void Start()
    {
        baseHealth = 150;
    }

    void Awake()
    {
        healthText = GameObject.Find("HealthText");
    }

    void FixedUpdate()
    {
        invincibility--;

        if(baseHealth <= 0)
        {
            Debug.Log("JE BENT HARSTIKKE DOOD");
            //go to gameoverscreen
            Application.LoadLevel(2);
        }
    }

    void Update()
    {
        //decrement invicibility counter over time
        invincibility -= Time.deltaTime;
        if (invincibility <= 0)
            invincibility = 0;

        healthText.gameObject.GetComponent<Text>().text = "Health: " + baseHealth;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "SouthSpirit" && invincibility <= 0)
        {
            invincibility = 5;
            baseHealth--;
        }
    }
}