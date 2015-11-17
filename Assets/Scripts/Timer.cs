using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{

	public Text timerText;
	public float startTime;
	private bool timerStop = false;
	private int count;

	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
	}
	void OnGUI()
	{
		if(GUI.Button(new Rect( 180, 60, 80, 25), "Stop Timer"))
				SendMessage("TimerStop");
	}

	// Update is called once per frame
	void Update () 
	{
		if(timerStop){
			return;
		}

		float time = Time.time - startTime;
		string minutes = ((int)time / 60).ToString("00");
		string seconds = (time % 60).ToString("00");

		timerText.text = minutes + ":" + seconds;



	}

	public void TimerStop()
	{
		timerStop = true;
		timerText.color = Color.yellow;
		Debug.Log(timerText.text + count);
	}
}
