using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{

	public WIN game1, game2, game3;
	public Image YOUWIN, YOULOSE;
	public bool winning, finished;

	private bool ending;
	// Use this for initialization
	void Start ()
	{
		YOUWIN = YOUWIN.GetComponent<Image>();
		YOULOSE = YOULOSE.GetComponent<Image>();
		game1 = game1.GetComponent<WIN>();
		game2 = game2.GetComponent<WIN>();
		game3 = game3.GetComponent<WIN>();
		YOUWIN.transform.position = new Vector3(-4000, - 4000, 0);
		YOULOSE.transform.position = new Vector3(-4000, - 4000, 0);
		winning = false;
		ending = false;
		finished = false;
	}
	
	// Update is called once per frame
	void Update () {

		winning = game1.Win || game2.Win || game3.Win;
		ending = game1.End || game2.End || game3.End;
		if (!finished)
		{
			if (ending &&  winning)
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

		if (finished)
		{
			new WaitForSeconds(4f);
			SceneManager.LoadScene("menu");
		}
	}
}
