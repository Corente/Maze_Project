using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QTE_Game_Moving_Phantom : MonoBehaviour {

	
	public Button myButton;
	private int score;
	private System.Random random;
	private int X_max;
	private int Y_max;
	private float timer;
	private bool win;
	private bool begin;
	private bool end;
	//public Image Loseimg;
	//public Image winmg;
	
	// Use this for initialization
	void Start () {
		myButton = GetComponent<Button>();
		//winmg = GetComponent<Image>();
		//Loseimg = GetComponent<Image>();
		score = 0;
		random = new System.Random();
		X_max = 600;
		Y_max = 300;
		myButton.onClick.AddListener(target);
		myButton.onClick.AddListener(randompos);
		timer = 10.0f;
		transform.position = new Vector3(-400, -400, 0);
		//winmg.transform.position = new Vector3(-400, -400, 0);
		//Loseimg.transform.position = new Vector3(-400, -400, 0);
		win = false;
		begin = true;
		end = false;
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		
		if (begin && timer <= 7)
		{
			randompos();
			begin = false;
		}	
		if (timer <= 0)
		{
			myButton.enabled = false;
			transform.position = new Vector3(-4000, -4000, 0);
			if (score >= 7)
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
