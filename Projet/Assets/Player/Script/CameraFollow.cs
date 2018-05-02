using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public Transform player;
	public bool TourDuJoueur;
	
	// Update is called once per frame
	void Update ()
	{
		if (TourDuJoueur)
		{
			transform.position = player.position + new Vector3(0,2,0);
			transform.rotation = player.rotation;
		}
	}
}
