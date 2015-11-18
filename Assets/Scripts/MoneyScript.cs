using UnityEngine;
using System.Collections;

public class MoneyScript : MonoBehaviour {

	//For defending your base
	private int MoneyCounter = 0;
	//For attacking another base
	private int CreditCounter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoneyCounter++;
		Debug.Log("Money: " + MoneyCounter);
	}


}
