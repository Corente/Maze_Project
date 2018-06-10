using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AficheTemps : MonoBehaviour
{
	public Text texte;
	public Canvas canvas;

	public void MettreTemps(string temps)
	{
		texte.text = temps;
	}

	public void ActiveCanvas()
	{
		canvas.enabled = true;
	}

	public void DesactiveCanavs()
	{
		canvas.enabled = false;
	}

}
