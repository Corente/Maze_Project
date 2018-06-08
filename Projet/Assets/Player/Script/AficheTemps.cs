using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AficheTemps : MonoBehaviour
{
	public Text texte;

	public void MettreTemps(string temps)
	{
		texte.text = temps;
	}

}
