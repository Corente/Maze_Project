using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Artefact : Maze
{
	public GameObject tree;
	public GameObject statue;
	public GameObject coin;
	public Maze maze;
	protected GameObject artefact;

	public bool isTaken;

	
	/*
	 * At the beginning
	 */
	
	private void Start()
	{
		isTaken = false;
		artefact = Creation();
	}


	private void Update()
	{
		
		if (isTaken)
		{
			Destroy(artefact);
		}
	}
	/*
	 * Function on collision
	 */

	private void OnTriggerEnter(Collider other)
	{
		
		Destroy(gameObject);
		/*if (other.gameObject.CompareTag("Player"))
		{
			//Destroy(artefact);
			//artefact = Creation();
			isTaken = true;
		}*/
	}

	/*
	 * Creation d'un nouvel artefact
	 */
	
	public GameObject Creation()
	{
		GameObject gameObject;
		int rdn = Random.Range(0, 3);
		if (rdn == 1)
		{
			artefact = tree;
		}
		else if (rdn == 2)
		{
			artefact = statue;
		}
		else
		{
			artefact = coin;
		}
		float x = Random.Range(0, 9);
		float z = Random.Range(1, 10);
		float y = 3;
		
		//grid[(int) x, (int) z].AMB = Instantiate(artefact, new Vector3((float) (grid[(int) x, (int) z]).xpos * 20, y, (float) (grid[(int) x, (int) z]).zpos * 20), new Quaternion(0, 0, 0, 0));
		return grid[(int) x, (int) z].AMB;
	}
}
