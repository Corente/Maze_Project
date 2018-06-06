using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SynchroTexte : NetworkBehaviour
{
	public string Ligne_j1;
	public string Direction_J1;
	
	public string Ligne_j2;
	public string Direction_J2;
	
	public string Ligne_j3;
	public string Direction_J3;
	
	public string Ligne_j4;
	public string Direction_J4;
	
	private  GameObject[] players;

	public void Update()
	{
		players =  GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < players.Length; i++)
		{
			Variables_texte varibales = players[i].GetComponent<Variables_texte>();
			
			if (i == 0)
			{
				Ligne_j1 = varibales.Ligne;
				Direction_J1 = varibales.Direction;
			}
			else if (i == 1)
			{
				Ligne_j2 = varibales.Ligne;
				Direction_J2 = varibales.Direction;
			}
			else if (i == 2)
			{
				Ligne_j3 = varibales.Ligne;
				Direction_J3 = varibales.Direction;
			}
			else if (i == 3)
			{
				Ligne_j4 = varibales.Ligne;
				Direction_J4 = varibales.Direction;
			}
		}
	}

	//test
	
	public string Direction_Joueur()
	{
		return Direction_J1;
	}
	
	public string Ligne_Joueur()
	{
		return Ligne_j1;
	}
}
