using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Variables_texte : NetworkBehaviour 
{
	public InputField ligne;
	public InputField direction;

	public string GetDirection()
	{
		return direction.text;
	}

	public string GetLigne()
	{
		return ligne.text;
	}
}
