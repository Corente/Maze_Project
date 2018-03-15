using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationNoSmooth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			transform.Translate(0, 0, 20);
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			transform.Rotate(0, 180, 0);
			//transform.Translate(0, 0, 10);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			transform.Rotate(0, -90, 0);
			//transform.Translate(0, 0, 10);
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.Rotate(0, 90, 0);
			//transform.Translate(0, 0, 10);
		}
	}
}
