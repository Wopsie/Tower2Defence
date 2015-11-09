using UnityEngine;
using System.Collections;

public class playerBase : Health
{
	void OnCollissionEnter()
	{
		Debug.Log(baseHealth);
		baseHealth--;
		Debug.Log(baseHealth);
	}
}
