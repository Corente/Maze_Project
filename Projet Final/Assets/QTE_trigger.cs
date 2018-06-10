using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QTE_trigger : MonoBehaviour
{

	private int posx, posz;
	public Camera cam;
	public Move camMove;
	private GameObject cube;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player"))
		{
			other.GetComponentInParent<Camera>().enabled = false;
			cam.enabled = true;
			camMove.isQTE = true;
			
			
		}
		
		
	}

	public int Posx
	{
		get { return posx; }
		set { posx = value; }
	}
	public int Posz
	{
		get { return posz; }
		set { posz = value; }
	}

	public GameObject Cube
	{
		get { return cube; }
		set { cube = value; }
	}
}
