using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Variables_texte : NetworkBehaviour 
{
	public string Ligne;
	public string Direction;

	public InputField ligne;
	public InputField direction;

	public void Get_text()
	{
		Ligne = ligne.text;
		Direction = direction.text;
	}
}
