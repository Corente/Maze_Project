using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CanvasVisibleJ1 : NetworkBehaviour
{

	public Canvas canvas;
	public Canvas Score;
	public Canvas Ready;
	
	
	
	void Start () 
	{
		if (!isLocalPlayer)
		{
			canvas.enabled = false;
			Score.enabled = false;
			Ready.enabled = false;
		}
	}
	
	void Update() 
	{
		if (!isLocalPlayer)
		{
			canvas.enabled = false;
			Score.enabled = false;
			Ready.enabled = false;
		}
	}
}
