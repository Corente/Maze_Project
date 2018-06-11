using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changement : MonoBehaviour 
{
	public void Change ()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		SceneManager.LoadScene("TestQTE");
	}
}
