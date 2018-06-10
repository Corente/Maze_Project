using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class End : MonoBehaviour
{

	public WIN game1, game2, game3;
	
	public Image YOUWIN, YOULOSE;
	public bool winning, finished;
	public bool QTE;
	private bool ending;

	private Collider player;

	public Playing starter;
	// Use this for initialization
	void Start ()
	{
		YOUWIN = YOUWIN.GetComponent<Image>();
		YOULOSE = YOULOSE.GetComponent<Image>();
		game1 = game1.GetComponent<WIN>();
		game2 = game2.GetComponent<WIN>();
		game3 = game3.GetComponent<WIN>();
	
		QTE = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (QTE)
		{
			winning = game1.Win || game2.Win || game3.Win;
			ending = game1.End || game2.End || game3.End;
			if (!finished)
			{
				if (ending && winning)
				{
					YOUWIN.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
					finished = true;
				}
				else if (ending && !winning)
				{
					YOULOSE.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
					finished = true;
				}
			}
			else
			{
				start2();
			}

			if (finished)
			{
				QTE = false;
				game1.QTE = false;
				game2.QTE = false;
				game3.QTE = false;
				starter.QTE = false;
				finished = false;

				player.GetComponentInParent<Camera>().enabled = true;

			}
		}
	}

	public void start2()
	{
		YOUWIN.transform.position = new Vector3(-4000, - 4000, 0);
		YOULOSE.transform.position = new Vector3(-4000, - 4000, 0);
		winning = false;
		ending = false;
		finished = false;
	}
	
	public Collider Player
	{
		get { return player; }
		set { player = value; }
	}
}
