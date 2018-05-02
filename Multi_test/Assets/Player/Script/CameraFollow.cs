using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
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
			Cam.transform.position = new Vector3(147,440,173);
			Cam.transform.rotation = new Quaternion(87.84701f,0f,0f,0f);
		}
	}
}
