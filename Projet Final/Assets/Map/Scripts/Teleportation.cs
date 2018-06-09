using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
	private Vector3 destination;
	private System.Random Random;
	
	// Use this for initialization
	void Start () 
	{
		Random = new System.Random();
		destination = new Vector3(transform.position.x + Random.Next(-3, 3) * 20, transform.position.y , this.transform.position.z + Random.Next(-3, 3) * 20);
	}
	
	// Update is called once per frame
	void Update () 
	{
		destination = new Vector3(transform.position.x + Random.Next(-3,3)  * 20, transform.position.y, this.transform.position.z + Random.Next(-3, 3) * 20);
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("teleportxx"))
		{
			Debug.Log("Collision : teleportxx");
			transform.position = destination;
		}
			
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene("QTE");
		}
		/*if (other.CompareTag("QTE"))
		{

			SceneManager.LoadScene("QTE");
		}*/
	}
}