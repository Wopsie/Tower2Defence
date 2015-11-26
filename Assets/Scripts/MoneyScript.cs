using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {
	
	public static int moneyCounter = 0; //For defending your base

    [SerializeField]    private GameObject moneyText;

    void Start()
    {
        moneyCounter = 20;
    }

    void Awake()
    {
        moneyText = GameObject.Find("MoneyText");
    }

    void Update()
    {
        moneyText.gameObject.GetComponent<Text>().text = "Money: " + moneyCounter;
        Debug.Log(moneyCounter);
    }

	public void AddMoney(){
		moneyCounter++;
		Debug.Log("Money: " + moneyCounter);
	}
}
