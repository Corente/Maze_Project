using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QTE_Game_Quick : WIN {
	
	public Button myButton;
	public Image rules;
	private int score;

	// Use this for initialization
	void Start () {
		myButton = GetComponent<Button>();
		rules = rules.GetComponent<Image>();
		X_max = Screen.width;
		Y_max = Screen.height;
		myButton.onClick.AddListener(target);
		
		start2();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (QTE)
		{
			timer -= Time.deltaTime;

			if (enabled && begin && timer <= 7)
			{
				timer = 7;
				transform.position = new Vector3(X_max / 2, Y_max / 2, 0);
				begin = false;
				rules.enabled = true;
			}
			if (enabled && !end && timer <= 0)
			{
				rules.enabled = false;
				myButton.enabled = false;
				transform.position = new Vector3(-4000, -4000, 0);
				if (score >= 30)
					win = true;
				hasWin();
				enabled = false;
			}
		}
		else
			start2();

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

	public void start2()
	{
		score = 0;
		timer = 12.0f;
		transform.position = new Vector3(-400, -400, 0);
		rules.enabled = false;
		win = false;
		begin = true;
		end = false;
	}
	
}

