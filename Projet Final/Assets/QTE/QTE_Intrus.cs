 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QTE_Intrus : WIN
{
	public Button btn;
	public Image rules;
	public Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11, btn12;
	private List<Button> listbtn;
	private System.Random random;

	// Use this for initialization
	void Start()
	{
		QTE = false;
		
		btn = btn.GetComponent<Button>();
		btn1 = btn1.GetComponent<Button>();
		btn2 = btn2.GetComponent<Button>();
		btn3 = btn3.GetComponent<Button>();
		btn4 = btn4.GetComponent<Button>();
		btn5 = btn5.GetComponent<Button>();
		btn6 = btn6.GetComponent<Button>();
		btn7 = btn7.GetComponent<Button>();
		btn8 = btn8.GetComponent<Button>();
		btn9 = btn9.GetComponent<Button>();
		btn10 = btn10.GetComponent<Button>();
		btn11 = btn11.GetComponent<Button>();
		btn12 = btn12.GetComponent<Button>();
		listbtn = new List<Button>();
		listbtn.Add(btn);
		listbtn.Add(btn1);
		listbtn.Add(btn2);
		listbtn.Add(btn3);
		listbtn.Add(btn4);
		listbtn.Add(btn5);
		listbtn.Add(btn6);
		listbtn.Add(btn7);
		listbtn.Add(btn8);
		listbtn.Add(btn9);
		listbtn.Add(btn10);
		listbtn.Add(btn11);
		listbtn.Add(btn12);
		rules = rules.GetComponent<Image>();
		random = new System.Random();
		X_max = Screen.width;
		Y_max = Screen.height;


		start2();
	}

	// Update is called once per frame
	void Update()
	{
		if (QTE)
		{
			timer -= Time.deltaTime;

			if (enabled && begin && timer <= 7)
			{
				foreach (var bouton in listbtn)
				{
					randompos(bouton);
				}
				rules.enabled = true;
				begin = false;
			}
			if (enabled && !end && timer <= 0)
			{
				rules.enabled = false;
				enable();
				lose();
			}
		}
		else
		{
			start2();
		}

	}

//FONCTIONS

	public void enable()
	{
		
		foreach (var bouton in listbtn)
		{
			bouton.enabled = false;
			bouton.transform.position = new Vector3(-4000, -4000, 0);
		}
		end = true;
		enabled = false;
	}

	public void lose()
	{
		win = false;
	}

	public void winning()
	{
		win = true;
	}



	public void randompos(Button btns)
	{
		int x = random.Next(10, X_max - 10);
		int y = random.Next(10, Y_max - 10);
		btns.transform.position = new Vector3(x, y, 0);
	}

	public void start2()
	{			
		rules.enabled = false;
		begin = true;
		end = false;
		win = false;
		timer = 12.0f;	
		for (int i = 0; i < listbtn.Count; i++)
		{
			listbtn[i].transform.position = new Vector3(-4000, -4000, 0);
			listbtn[i].onClick.AddListener(enable);
			if (i != 0)
			{
				listbtn[i].onClick.AddListener(lose);
			}
			else
			{
				listbtn[i].onClick.AddListener(winning);
			}
		}
	}
}