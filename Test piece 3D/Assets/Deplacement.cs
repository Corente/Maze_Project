using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deplacement : MonoBehaviour
{

	public Rigidbody rb;

	public float avant = 50f;

	public float arriere = -50f;

	public float gauche = -50f;

	public float droite = 50f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("z"))
		{
			rb.AddForce(avant*Time.deltaTime,0,0);
		}
		if (Input.GetKey("q"))
		{
			rb.AddForce(0,0,gauche*Time.deltaTime);
		}
		if (Input.GetKey("d"))
		{
			rb.AddForce(0,0,droite*Time.deltaTime);
		}
		if (Input.GetKey("s"))
		{
			rb.AddForce(arriere*Time.deltaTime,0,0);
		}
		
		
	}
}
