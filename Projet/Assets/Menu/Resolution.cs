using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour {

	// Use this for initialization
	void Start () {
         int width = 610; // or something else
         int height= 760; // or something else
         bool isFullScreen = false; // should be windowed to run in arbitrary resolution
         int desiredFPS = 60; // or something else
     
         Screen.SetResolution (width , height, isFullScreen, desiredFPS );
     }

	
	// Update is called once per frame
	void Update () {
		
	}
}
