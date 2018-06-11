using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player : NetworkBehaviour 
{

	public bool hasToMoveU;
	public bool hasToMoveD;
	public bool hasToMoveL;
	public bool hasToMoveR;

	public int i;

	public List<string> _objects;
	public int _score;
	public Text toPrint;
	public Text youWin;

	public int bonustemps;

	public Player(List<string> objects)
	{
		_objects = objects;
	}

	void Start () 
	{
		if (isLocalPlayer)
		{
			hasToMoveU = false;
			hasToMoveD = false;
			hasToMoveL = false;
			hasToMoveR = false;
			i = 0;
			_objects = new List<string>();
			_score = 0;
			toPrint.text = "Score : " + "0";
			youWin.text = "";
			bonustemps = 0;
		}
		
		
	}
	
	void Update () 
	{
		if (isLocalPlayer)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow) || hasToMoveU)
			{
				if (i % 20 < 10)
				{
					transform.Translate(0, 0.02f, 0);
				}
				else
				{
					transform.Translate(0,-0.02f,0);
				}
			
			
			
				transform.Translate(0, 0, 0.2f);
				i += 1;
				hasToMoveU = true;
				if ( i == 100)
				{
					hasToMoveU = false;
					i = 0;
				}
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) || hasToMoveD)
			{
				transform.Rotate(0, 5f, 0);
				i += 5;
				hasToMoveD = true;
				if ( i == 180)
				{
					hasToMoveD = false;
					i = 0;
				}
			}
			else if (Input.GetKeyDown(KeyCode.LeftArrow) || hasToMoveL)
			{
				transform.Rotate(0, -5f, 0);
				i += 5;
				hasToMoveL = true;
				if ( i == 90)
				{
					hasToMoveL = false;
					i = 0;
				}
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow) || hasToMoveR)
			{
				transform.Rotate(0, 5f, 0);
				i += 5;
				hasToMoveR = true;
				if ( i == 90)
				{
					hasToMoveR = false;
					i = 0;
				}
			}
			_score = Score();
			toPrint.text = "Score : " + _score.ToString();
			YouWin();
			bonustemps = GameObject.Find("MB").GetComponent<MalusBonus>().bonusTemps;
		}
		
	}
	
	private void OnTriggerEnter(Collider other)
	{
		string artefact = other.gameObject.name;
		int i = 0;
		if (other.gameObject.CompareTag("Artefact"))
		{
			/*artefact = other.gameObject.name;
			_objects.Add(new Artefact(artefact));*/
			_objects.Add(artefact);
		}
		else if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Hello!");
		}
	}

	public int Score()
	{
		return _objects.Count;
	}

	public void YouWin()
	{
		if (Score() == 3)
		{
			youWin.text = "You are free !";
		}
	}
}
