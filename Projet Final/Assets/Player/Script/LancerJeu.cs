using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerJeu : MonoBehaviour 
{
	public void lancer()
	{
		GameObject.Find("Game").GetComponent<Game>().gogogogo();
		
	}
	
	
}
