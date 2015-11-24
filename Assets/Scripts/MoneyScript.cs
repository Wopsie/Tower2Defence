using UnityEngine;
using System.Collections;

public class MoneyScript : MonoBehaviour {
	
	public int MoneyCounter = 0; //For defending your base
	public int CreditCounter = 0; //For attacking another base

	public void AddMoney(){
		MoneyCounter++;
		Debug.Log("Money: " + MoneyCounter);
	}

	public void AddCredits(){
		CreditCounter++;
		Debug.Log("Credits: " + CreditCounter);

	}

	void Update () {

	}




}
