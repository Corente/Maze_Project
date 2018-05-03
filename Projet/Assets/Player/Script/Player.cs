using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour {

	public bool hasToMoveU;
	public bool hasToMoveD;
	public bool hasToMoveL;
	public bool hasToMoveR;

	public int i;

	public List<Artefact> _objects;
	public int _score;

	public Player(List<Artefact> objects)
	{
		_objects = objects;
	}

	void Start () {
		hasToMoveU = false;
		hasToMoveD = false;
		hasToMoveL = false;
		hasToMoveR = false;
		i = 0;
		_objects = new List<Artefact>();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow) || hasToMoveU)
		{
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
	}
	
	private void OnTriggerEnter(Collider other)
	{
		string artefact;
		int i = 0;
		if (other.gameObject.CompareTag("Artefact"))
		{
			artefact = other.gameObject.name;
			_objects.Add(new Artefact(artefact));
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
}
