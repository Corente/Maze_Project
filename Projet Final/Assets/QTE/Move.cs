using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{


	private int i;
	private Vector3 initpos;
	public bool isQTE;

	public Canvas QTECanvas;
	// Use this for initialization
	void Start ()
	{
		enabled = false;
		i = 0;
		isQTE = false;
		initpos = transform.position;
		QTECanvas.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (isQTE)
		{
			enabled = true;
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
			if (i > 5)
			{
				isQTE = !isQTE;
				transform.position = initpos;
				QTECanvas.GetComponent<Canvas>().enabled = true;
				QTECanvas.GetComponentInChildren<Playing>().QTE = true;
			}
		}
		

	}
}
