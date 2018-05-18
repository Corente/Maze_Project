using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CanvasScript : NetworkBehaviour 
{
// Use this for initialization
	public Canvas canvas;
	
	void Start()
	{
		if (!isLocalPlayer)
		{
			canvas.enabled = true;
		}
	}
}
