using UnityEngine;
using System.Collections;

public class playerBase : Health
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

	void OnCollissionEnter()
	{
		Debug.Log(baseHealth);
		baseHealth--;
		Debug.Log(baseHealth);
	}

}
