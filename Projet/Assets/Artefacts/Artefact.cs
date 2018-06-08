using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artefact : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		
		Destroy(gameObject);
		/*if (other.gameObject.CompareTag("Player"))*/
	}
}
