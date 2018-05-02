using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
	public Transform destination;
	
	// Use this for initialization
	void Start () {
		
		destination = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		OnTriggerEnter();
	}
	
	private void OnTriggerEnter() {
		Debug.Log(this.tag);
		if (CompareTag("Player"))
			transform.position = destination.position;
	}
}
