using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
public class CameraFollow : NetworkBehaviour
{

	public Camera Cam;
	public bool TourDuJoueur;

	
	
	// Update is called once per frame
	void Update ()
	{

		if (!isLocalPlayer)
		{
			Cam.enabled = false;
		}
		else
		{
			Came();
		}
		
	}

	void Came()
	{
		if (TourDuJoueur)
		{
			Cam.transform.position = transform.position + new Vector3(0f,2f);
			Cam.transform.rotation = transform.rotation;
		}
		else
		{
			/*Cam.transform.position = new Vector3(138,460,239);
			Cam.transform.rotation = new Quaternion(89.079f,0f,0f,0f);
			Debug.Log("bonjour");*/
		}
	}
}
