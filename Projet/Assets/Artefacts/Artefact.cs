using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Artefact : MonoBehaviour
{
	public ParticleSystem effect;

	public string type;

	private void Start()
	{
		effect.GetComponent<ParticleSystem>().Stop();
	}

	public Artefact(string artefacts)
	{
		type = artefacts;
	}
	
	
	private void OnTriggerEnter(Collider other)
	{
		int i = 0;
		if (other.gameObject.CompareTag("Player"))
		{
			/*effect.GetComponent<ParticleSystem>().Play();
			float timer = 15;
			while (timer > 0)
			{
				gameObject.transform.Translate(0, 0, 0.1f);
				timer -= 1;
			}*/
			Destroy(gameObject);
			
		}
	}
}
