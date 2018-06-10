using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Variables_texte : NetworkBehaviour 
{
	public InputField ligne;
	public InputField direction;

	private string LIGNE;
	private string DIRECTION;

	public bool ok = false;

	public string GetDirection()
	{
		return DIRECTION;
	}

	public string GetLigne()
	{
		return LIGNE;
	}

	public void Mettre()
	{
		LIGNE = ligne.text;
		DIRECTION = direction.text;
		ok = true;
	}
}
