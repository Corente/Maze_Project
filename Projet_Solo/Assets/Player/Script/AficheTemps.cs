using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AficheTemps : MonoBehaviour
{
	public Text texte;
	public Canvas c;

	public void MettreTemps(string temps)
	{
		c.enabled = true;
		texte.text = temps;
		
	}

	public void Stop()
	{
		c.enabled = false;
	}

}
