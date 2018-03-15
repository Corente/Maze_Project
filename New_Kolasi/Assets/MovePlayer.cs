using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{
	public bool hasToMoveU;
	public bool hasToMoveD;
	public bool hasToMoveL;
	public bool hasToMoveR;

	public Vector3 initialPosition;

	public Quaternion initialRotation;
	// Use this for initialization
	void Start ()
	{
		hasToMoveU = false;
		hasToMoveD = false;
		hasToMoveL = false;
		hasToMoveR = false;
		initialPosition = transform.position;
		initialRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow) || hasToMoveU)
		{
			transform.Translate(0, 0, 0.1f);
			hasToMoveU = transform.position.z < (initialPosition + new Vector3(0, 0, 10)).z;
			if (!hasToMoveU)
			{
				initialPosition = transform.position;
			}
			//transform.Translate(0, 0, 10);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) || hasToMoveD)
		{
			transform.Translate(0, 0, -0.1f);
			hasToMoveD = transform.position.z > (initialPosition + new Vector3(0, 0, -10)).z;
			if (!hasToMoveD)
			{
				initialPosition = transform.position;
				initialRotation = transform.rotation;
			}
			/*transform.Rotate(0, 180, 0);
			transform.Translate(0, 0, 10);*/
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || hasToMoveL)
		{
			transform.Translate(-0.1f, 0, 0);
			hasToMoveL = transform.position.x > (initialPosition + new Vector3(-10, 0, 0)).x;
			if (!hasToMoveL)
			{
				initialPosition = transform.position;
				initialRotation = transform.rotation;
			}
			/*transform.Rotate(0, -90, 0);
			transform.Translate(0, 0, 10);*/
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) || hasToMoveR)
		{
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				transform.Rotate(0, 90, 0);
			}
			transform.Translate(0, 0, 0.1f);
			hasToMoveR = transform.position.x < (initialPosition + new Vector3(10, 0, 0)).x;
			if (!hasToMoveR)
			{
				initialPosition = transform.position;
				initialRotation = transform.rotation;
			}
			/*transform.Rotate(0, 90, 0);
			transform.Translate(0, 0, 10);*/
		}
	}
}
