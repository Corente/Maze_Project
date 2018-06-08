using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


	private int i;
	// Use this for initialization
	void Start ()
	{
		i = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{

		
		if (i <= 2)
		{
			transform.Translate(0, 1, 1);
			i += 1;
		}

		if (i > 2 && i <= 5)
		{
				transform.Translate(0, 0, 1);
				i += 1;
			
		}
		
	}
}
