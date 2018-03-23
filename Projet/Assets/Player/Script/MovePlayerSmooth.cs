using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MovePlayerSmooth : MonoBehaviour {

	public bool hasToMoveU;
	public bool hasToMoveD;
	public bool hasToMoveL;
	public bool hasToMoveR;

	public int i;
	// Use this for initialization
	void Start () {
		hasToMoveU = false;
		hasToMoveD = false;
		hasToMoveL = false;
		hasToMoveR = false;
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow) || hasToMoveU)
		{
			transform.Translate(0, 0, 0.1f);
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
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				transform.Rotate(0, 180, 0);
			}
			hasToMoveD = true;
			transform.Translate(0, 0, 0.1f);
			i += 1;
			if (i == 100)
			{
				hasToMoveD = false;
				i = 0;
			}
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || hasToMoveL)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				transform.Rotate(0, -90, 0);
			}
			transform.Translate(0, 0, 0.1f);
			i += 1;
			hasToMoveL = true;
			if (i == 100)
			{
				hasToMoveL = false;
				i = 0;
			}
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || hasToMoveR)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				transform.Rotate(0, 90, 0);
			}
			transform.Translate(0, 0, 0.1f);
			i += 1;
			hasToMoveR = true;
			if (i == 100)
			{
				i = 0;
				hasToMoveR = false;
			}
		}
	}
}
