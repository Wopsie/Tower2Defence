using UnityEngine;
using System.Collections;

public class DirectionButton : MonoBehaviour 
{
    private int buttonID;
    public static Transform pTarget;

	void Start () 
    {
        //identify button
	    switch(gameObject.tag)
        {
            case "EastButton":
                buttonID = 1;
                break;
            case "WestButton":
                buttonID = 2;
                break;
            case "NorthButton":
                buttonID = 3;
                break;
            case "SouthButton":
                buttonID = 4;
                break;
        }
	}

    //check whenever button is clicked
    void OnMouseDown()
    {
        switch(buttonID)
        {
            case 1:
                pTarget = GameObject.FindGameObjectWithTag("EastBase").transform;
                break;
            case 2:
                pTarget = GameObject.FindGameObjectWithTag("WestBase").transform;
                break;
            case 3:
                pTarget = GameObject.FindGameObjectWithTag("NorthBase").transform;
                break;
            case 4:
                Debug.Log("Upgrade turrets");
                break;
        }
    }

    //reset target when button is released
    void OnMouseUp()
    {
        pTarget = null;
    }
}