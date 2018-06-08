using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QTE_Game_Moving_Phantom : WIN {

	
	public Button myButton;
	public Image rules;
	private int score;
	private System.Random random;

	// Use this for initialization
	void Start () {
		myButton = GetComponent<Button>();
		rules = rules.GetComponent<Image>();
		score = 0;
		random = new System.Random();
		
		myButton.onClick.AddListener(target);
		myButton.onClick.AddListener(randompos);
		transform.position = new Vector3(-400, -400, 0);
		rules.enabled = false;
		
		timer = 12.0f;
		X_max = Screen.width - 10;
		Y_max = Screen.height - 10;
		win = false;
		begin = true;
		end = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer -= Time.deltaTime;
		
		if (enabled && begin && timer <= 7)
		{
			timer = 7;
			randompos();
			begin = false;
			rules.enabled = true;
		}	
		if (enabled && !end && timer <= 0)
		{
			myButton.enabled = false;
			rules.enabled = false;
			transform.position = new Vector3(-4000, -4000, 0);
			if (score >= 6)
				win = true;
			hasWin();	
			enabled = false;
		}
	}

	public void target()
	{
		score++;
	}

	public void randompos()
	{
		int x = random.Next(10,X_max - 10);
		int y = random.Next(10,Y_max - 10 );
		int z = random.Next(0, 2);
		transform.position = new Vector3(x, y, z);
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
