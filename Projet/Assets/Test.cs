using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Test : MonoBehaviour
{

	
	public GameObject Player2;
	public GameObject Player3;
	public GameObject Player4;

	public NetworkManager Network;
	
	
	void Update () 
	{
		GameObject[] liste = GameObject.FindGameObjectsWithTag("Player");
		if (liste.Length == 1)
		{
			Network.playerPrefab = Player2;
		}
		else if (liste.Length == 2)
		{
			Network.playerPrefab = Player3;
		}
		else if (liste.Length == 3)
		{
			Network.playerPrefab = Player4;
		}
	}
}
