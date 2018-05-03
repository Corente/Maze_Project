using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class MovePlayerSmooth : NetworkBehaviour {

	private bool hasToMoveU;
	private bool hasToMoveD;
	private bool hasToMoveL;
	private bool hasToMoveR;
	private int i;
	
	// Use this for initialization
	void Start () 
	{
		hasToMoveU = false;
		hasToMoveD = false;
		hasToMoveL = false;
		hasToMoveR = false;
		i = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isLocalPlayer)
		{
			return;
		}
		else
		{
			deplacement();
		}
		
		
		
		
	}

	void deplacement()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow) || hasToMoveU)
		{
			transform.Translate(0, 0, 0.1f);
			i += 1;
			hasToMoveU = true;
			if ( i == 200)
			{
				hasToMoveU = false;
				i = 0;
			}
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) || hasToMoveD)
		{
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				transform.Rotate(0, 180, 0);
			}
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || hasToMoveL)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				transform.Rotate(0, -90, 0);
			}
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || hasToMoveR)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				transform.Rotate(0, 90, 0);
			}
		}
	}
}
