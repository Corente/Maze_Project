using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QTE_Intrus_Lose : MonoBehaviour {

	
	public Button myButton;
	private System.Random random;
	private int X_max;
	private int Y_max;
	private float timer;
	private bool win;
	private bool begin;
	
	// Use this for initialization
	void Start () {
		myButton = GetComponent<Button>();
		random = new System.Random();
		X_max = 600;
		Y_max = 300;
		myButton.onClick.AddListener(target);
		timer = 13.0f;
		transform.position = new Vector3(-400, -400, 0);
		win = false;
		begin = true;
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		
		if (begin && timer <= 10)
		{
			randompos();
			begin = false;
		}	
		if (timer <= 0)
		{
			if (win)
				Debug.Log("YOU WIN" );
			else
				Debug.Log("YOU LOSE" );
		}
		
	}

	public void target()
	{
		win = false;
		myButton.enabled = false;
		//transform.position = new Vector3(-4000, -4000, 0);
		timer = 0;
	}

	public void randompos()
	{
		int x = random.Next(10,X_max - 10);
		int y = random.Next(10,Y_max - 10 );
		transform.position = new Vector3(x, y, 0);
	}
	
}


