using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerSmooth : MonoBehaviour {

	public bool hasToMoveU;
	public bool hasToMoveD;
	public bool hasToMoveL;
	public bool hasToMoveR;

	public Vector3 initialPosition;
	// Use this for initialization
	void Start () {
		hasToMoveU = false;
		hasToMoveD = false;
		hasToMoveL = false;
		hasToMoveR = false;
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.UpArrow) || hasToMoveU)
		{
			transform.Translate(0, 0, 0.1f);
			hasToMoveU = transform.position.z < (initialPosition + new Vector3(0, 0, 1)).z;
			if (!hasToMoveU)
			{
				initialPosition = transform.position;
			}
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			transform.Rotate(0, 180, 0);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.Rotate(0, -90, 0);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.Rotate(0, 90, 0);
		}
		/*else if (Input.GetKeyDown(KeyCode.DownArrow) || hasToMoveD)
		{
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				transform.Rotate(0, 180, 0);
			}
			transform.Translate(0, 0, 0.1f);
			hasToMoveD = transform.position.z > (initialPosition + new Vector3(0, 0, -10)).z;
			if (!hasToMoveD)
			{
				initialPosition = transform.position;
			}
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || hasToMoveL)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				transform.Rotate(0, -90, 0);
			}
			transform.Translate(0, 0, 0.1f);
			hasToMoveL = transform.position.x > (initialPosition + new Vector3(-10, 0, 0)).x;
			if (!hasToMoveL)
			{
				initialPosition = transform.position;
			}
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || hasToMoveR)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				transform.Rotate(0, 90, 0, Space.Self);
			}
			transform.Translate(0, 0, 0.1f);
			hasToMoveR = transform.position.x <= (initialPosition + new Vector3(10, 0, 0)).x;
			if (!hasToMoveR)
			{
				initialPosition = transform.position;
			}
		}*/
	}
}
