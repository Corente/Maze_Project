using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QTE_Game_Quick : MonoBehaviour {
	
	public Button myButton;
	private int score;
	private System.Random random;
	private int X_max;
	private int Y_max;
	private float timer;
	private bool win;
	private bool begin;
	private bool end;

	
	// Use this for initialization
	void Start () {
		myButton = GetComponent<Button>();

		score = 0;
		random = new System.Random();
		X_max = 600;
		Y_max = 300;
		myButton.onClick.AddListener(target);
		timer = 10.0f;
		transform.position = new Vector3(-400, -400, 0);
		win = false;
		begin = true;
		end = false;
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		
		if (begin && timer <= 7)
		{
			transform.position = new Vector3(400, 200, 0);
			begin = false;
		}	
		if (timer <= 0)
		{
			myButton.enabled = false;
			transform.position = new Vector3(-4000, -4000, 0);
			if (score >= 35)
				win = true;
			hasWin();
		}
		
		/*if(end)
		{
			if (win)
		{
			Debug.Log("YOU WIN : " + score);
			winmg.transform.position = new Vector3(300, 120, 0);
		}
		else
		{
			Debug.Log("YOU LOSE : " + score);
			Loseimg.transform.position = new Vector3(300, 120, 0);
		}
			
		}*/
	}

	public void target()
	{
		score++;
	}


	
	public bool hasWin()
	{
		if (!end)
		{
			if (win)
				Debug.Log("YOU WIN : " + score );
			else
				Debug.Log("YOU LOSE : " + score );			
		}
		end = true;
		return win;
	}
	
}

