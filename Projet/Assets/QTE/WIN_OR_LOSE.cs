using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UI;


public class WIN_OR_LOSE : QTE_Intrus
{

	public QTE_Intrus bad1;
	public QTE_Intrus bad2;
	private bool intrusfounded;
	private bool badcliked;
	private int win;
	private QTE_Intrus[] badies;
	private System.Random random2;
	
	// Use this for initialization
	void Start ()
	{
		bad1 = GetComponent<QTE_Intrus>();
		bad2 = GetComponent<QTE_Intrus>();
		myButton.onClick.AddListener(target);
		badcliked = true;
		intrusfounded = false;
		myButton.transform.position = new Vector3(-400, -400, 0);
		badies = new[] {bad1, bad2};
		win = 2;
		random2 = new System.Random();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Timer -= Time.deltaTime;
		if (Begin && Timer <= 5)
		{
			int x = random2.Next(10,600 - 10);
			int y = random2.Next(10,300 - 10 );
			myButton.transform.position = new Vector3(x, y, 0);
			Begin = false;
		}	
		
		foreach (var badguy in badies)
		{
			badcliked &= badguy.enabled;
		}
		
		if (badcliked == false)
		{
			Timer = 0;
			win = 0;
		}
		if (intrusfounded)
		{
			Timer = 0;
			win = 1;
		}
		if ((win == 1 || win == 0) && Timer == 0)
		{
			transform.position = new Vector3(-400, -400, 0);
			myButton.enabled = false;
			myButton.transform.position = new Vector3(-4000, -4000, 0);
			hasWin();		
		}
	}
	
	public void target()
	{
		intrusfounded = true;
		Timer = 0;
		hasWin();
	}

	public void hasWin()
	{
		if (win == 1)
			Debug.Log("YOU WIN");
		else
			Debug.Log("YOU LOSE");	
	}
	
}
