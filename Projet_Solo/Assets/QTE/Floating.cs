using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Floating : MonoBehaviour
{

	private int i;
	// Use this for initialization
	void Start ()
	{
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (i % 20 < 10)
		{
			transform.Translate(0, 0.1f, 0);
		}
		else
		{
			transform.Translate(0, -0.1f, 0);
		}
		
		i += 1;
	}
}
