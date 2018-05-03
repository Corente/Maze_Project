 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QTE_Intrus : MonoBehaviour {

	
	public Button myButton;
	private System.Random random;
	private int X_max;
	private int Y_max;
	private float timer;
	private bool begin;
	private bool end;
	
	// Use this for initialization
	void Start ()
	{
		myButton = GetComponent<Button>();
		random = new System.Random();
		timer = 8.0f;
		X_max = 600;
		Y_max = 300;
		transform.position = new Vector3(-400, -400, 0);
		begin = true;
		end = false;
		myButton.onClick.AddListener(enable);
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		
		if (begin && timer <= 5)
		{
			randompos();
			begin = false;
		}	
		if (end)
		{
			enabled = false;
			transform.position = new Vector3(-4000, -4000, 0);
			end = false;
		}
		
	}

//FONCTIONS
	
	public void enable()
	{
		enabled = false;
		transform.position = new Vector3(-4000, -4000, 0);
	}


	public void randompos()
	{
		int x = random.Next(10,X_max - 10);
		int y = random.Next(10,Y_max - 10 );
		transform.position = new Vector3(x, y, 0);
	}
	
	
// GETTERS SETTERS
	public float Timer
	{
		get { return timer; }
		set { timer = value; }
	}
	
	public bool Begin
	{
		get { return begin; }
		set { begin = value; }
	}
	
	public bool End
	{
		get { return end; }
		set { end = value; }
	}
}

