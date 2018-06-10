using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Playing : MonoBehaviour
{
	public Button start;
	public Image background, text;
	public WIN game1, game2, game3;
	private float timer;
	private int count;
	private bool begin;
	public bool QTE;
	
	// Use this for initialization
	void Start ()
	{
		game1 = game1.GetComponent<WIN>();
		game2 = game2.GetComponent<WIN>();
		game3 = game3.GetComponent<WIN>();
		start = start.GetComponent<Button>();
		background = background.GetComponent<Image>();
		text = text.GetComponent<Image>();
		start.onClick.AddListener(enable);
		QTE = false;
		start2();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (QTE)
		{
			count += 1;

			timer -= Time.deltaTime;

			if (!begin && timer <= 0)
			{
				enable();
			}
		}

	}
	
	public void enable()
	{
		begin = true;
		start.enabled = false;
		start.transform.position = new Vector3(-4000, -4000, 0);
		text.enabled = false;
		background.enabled = false;
		if (count % 3 == 0)
		{
			game1.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
			game1.Begin = true;
			game1.Timer = 7;
			game1.QTE = true;
			game2.enabled = false;
			game3.enabled = false;
			game2.Begin = false;
			game3.Begin = false;
		}
		else if (count % 3 == 1)
		{
			game2.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
			game2.Timer = 7;
			game2.QTE = true;
			game1.enabled = false;
			game3.enabled = false;
			game1.Begin = false;
			game3.Begin = false;
		}
		else
		{
			game3.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
			game3.Timer = 7;
			game3.QTE = true;
			game1.enabled = false;
			game2.enabled = false;
			game1.Begin = false;
			game2.Begin = false;
		}
	}

	public void start2()
	{
		timer = 5.0f;
		begin = false;
		count = 0;
		game1.transform.position = new Vector3(-4000, -4000, 0);
		game2.transform.position = new Vector3(-4000, -4000, 0);
		game3.transform.position = new Vector3(-5000, -5000, 0);
	}
}
