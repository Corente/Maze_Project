using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Movement : MonoBehaviour {

    private Button myButton;
	private System.Random random;
	private int X_max;
	private int Y_max;
	private float timer;
	private bool begin;
	private bool end;
	// Use this for initialization
	void Start () {
		myButton = GetComponent<Button>();
		random = new System.Random();
		timer = 8.0f;
		X_max = 600;
		Y_max = 300;
		transform.position = new Vector3(-400, -400, 0);
		begin = true;

	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;	
		if (begin && timer <= 5)
		{
			randompos();
			begin = false;
		}			
	}
	
	public void randompos()
	{
		int x = random.Next(10,X_max - 10);
		int y = random.Next(10,Y_max - 10 );
		myButton.transform.position = new Vector3(x, y, 0);
	}
}
