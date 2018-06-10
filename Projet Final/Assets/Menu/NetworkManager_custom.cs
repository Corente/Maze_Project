using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class NetworkManager_custom : NetworkManager
{

	/*public string InputFieldIP;
	public string Hostbutton;
	public string Joinbutton;
	public string Quitbutton;*/
	

	public void StartupHost()
	{
		Setport();
		singleton.StartHost();
	}

	void Setport()
	{
		singleton.networkPort = 7777;
	}

	public void Joingame()
	{
		//SetIpAdress();
		//Setport();
		NetworkManager.singleton.StartClient();
	}

	void SetIpAdress()
	{
		//string ipAdress = GameObject.Find("InputFieldAdress").transform.Find("Text").GetComponent<Text>().text;
		NetworkManager.singleton.networkAddress = "255785";
	}

	void SetupMenuSceneButtons()
	{
		
		GameObject.Find("Heberger").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("Heberger").GetComponent<Button>().onClick.AddListener(StartupHost);
		
		GameObject.Find("Rejoindre").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("Rejoindre").GetComponent<Button>().onClick.AddListener(Joingame);
					
	}

	void SetupOtherSceneButtons()
	{
		GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 0)
		{
			SetupMenuSceneButtons();
			
		}

		else
		{
			SetupOtherSceneButtons();
		}
	}
	
	
}
