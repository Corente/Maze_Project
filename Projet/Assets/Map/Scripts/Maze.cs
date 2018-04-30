using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Maze : MonoBehaviour
{

	public int width, height;
	public VisualBloc visualprefabbloc;

	public Bloc[,] grid;
	public VisualBloc[,] carte;

	private Vector2 _randomCellPos;

	protected VisualBloc visualBlocInit;

	int[] selection = new int[3];

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	public InputField ligne;
	public InputField direction;
	private string memoire_ligne;
	private string memoire_direction;
	
	
	private bool buton;

	private int temps;
	
	
	// Use this for initialization
	void Start () {
		grid = new Bloc[width,height];
		carte = new VisualBloc[width,height];
		Init();
		/*player1 = new GameObject("player1");
		player2 = new GameObject("player2");
		player3 = new GameObject("player3");
		player4 = new GameObject("player4");*/
		player1.transform.position = carte[0, 0].transform.position + new Vector3(0,3,0);
		player2.transform.position = carte[0, 8].transform.position + new Vector3(0,3,0);
		player3.transform.position = carte[8, 0].transform.position + new Vector3(0,3,0);
		player4.transform.position = carte[8, 8].transform.position + new Vector3(0,3,0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (temps == 240)
		{
			buton = false;
			ajout_Bloc(memoire_ligne,memoire_direction);
		}
		if (buton)
		{
			dico(memoire_ligne,memoire_direction);
			temps++;
		}
		
	}

	
//######################################################################################################################################################################################
//     AUTRES
	
	
	
	
	public void clicked()
	{
		if (ligne.text.Length != 0 && direction.text.Length != 0)
		{
			buton = true;
			memoire_direction = direction.text;
			memoire_ligne = ligne.text;
			temps = 0;
		}
	}

	
	
//#####################################################################################################################################################################################	
//     FONCTIONS QUI CREER LA MAP	
	
	
	
	
	void Init()
	{
		for (int j = 0; j < width; j++)
		{
			for (int i = 0; i < height; i++)
			{
				grid[j,i] = new Bloc();
				grid[j, i].xpos = j;
				grid[j, i].zpos = i;
			}
		}
		InitVisual();
		
	}

	

	void InitVisual()
	{
		
		for (int p = 0; p < carte.GetLength(0); p++)
		{
			for (int w = 0; w < carte.GetLongLength(1); w++)
			{

				Bloc bloc = grid[p, w];
				
				visualBlocInit = Instantiate(visualprefabbloc, new Vector3(bloc.xpos * 20, 0, (height - bloc.zpos)* 20), Quaternion.identity) as VisualBloc;

				carte[p, w] = visualBlocInit;
				int t = 0;
				while (t<bloc.rotate)
				{
					visualBlocInit.transform.Rotate(Vector3.back + new Vector3(0, -90, 0));
					t++;
				}
				
				visualBlocInit.transform.parent = transform;
				visualBlocInit._One.gameObject.SetActive(bloc.type1);
				visualBlocInit._Two.gameObject.SetActive(bloc.type2);
				visualBlocInit._Three.gameObject.SetActive(bloc.type3);
				visualBlocInit._West.gameObject.SetActive(!bloc.type1 && !bloc.type2 && !bloc.type3);
				visualBlocInit._Est.gameObject.SetActive(!bloc.type1 && !bloc.type2);
				visualBlocInit._South.gameObject.SetActive(!bloc.type2 && !bloc.type3);
				visualBlocInit.transform.name = bloc.xpos + "_" + bloc.zpos;

				
			}
		}
			
		
	}
	
	
//#############################################################################################################################################################################################
//  FONCTIONS QUI POUSSE LES BLOCS
	
	void PushBloc(int i, int j, int direction)
		{
			if (direction == 1)
			{
				for (int p = 0; p <= j; p++)
				{
					VisualBloc tmp = carte[i, p];
					Bloc bloc = grid[i, p];
					
					if (bloc.rotate != direction)
					{
						if (bloc.rotate == 2)
						{
							tmp.transform.Translate(0, 0,5 * Time.deltaTime);
						}
						else if (bloc.rotate == 3)
						{
							tmp.transform.Translate( 5 * Time.deltaTime,0, 0);
						}
						else if (bloc.rotate == 4)
						{
							tmp.transform.Translate( 0, 0,-5 * Time.deltaTime);
						}
					}
					else
					{
						tmp.transform.Translate(-5*Time.deltaTime,0,0);
					}
				}
				//Changebloc(j,i,1);
				
			}
			else if (direction == 2)
			{
				for (int p = i; p >= 0; p--)
				{
					Bloc bloc = grid[p, j];
					VisualBloc tmp = carte[p, j];

					if (bloc.rotate != direction)
					{
						if (bloc.rotate == 1)
						{
							tmp.transform.Translate(0, 0, 5 * Time.deltaTime);
						}
						else if (bloc.rotate == 3)
						{
							tmp.transform.Translate(0,0,-5*Time.deltaTime);
						}
						else if (bloc.rotate == 4)
						{
							tmp.transform.Translate(-5*Time.deltaTime,0,0);
						}
					}
					else
					{
						tmp.transform.Translate(5*Time.deltaTime,0,0);
					}
				}
				//Changebloc(j,i,2);
				
			}
			else if (direction == 3)
			{
				for (int p = j; p >= 0; p--)
				{
					VisualBloc tmp = carte[i, p];
					Bloc bloc = grid[i, p];
					
					if (bloc.rotate != direction)
					{
						if (bloc.rotate == 2)
						{
							tmp.transform.Translate(0, 0,-5 * Time.deltaTime);
						}
						else if (bloc.rotate == 1)
						{
							tmp.transform.Translate( 5 * Time.deltaTime,0, 0);
						}
						else if (bloc.rotate == 4)
						{
							tmp.transform.Translate( 0, 0,5 * Time.deltaTime);
						}
					}
					else
					{
						tmp.transform.Translate(-5*Time.deltaTime,0,0);
					}
				}
				//Changebloc(j,i,3);
				
			}
			else if (direction == 4)
			{
				for (int p = 0; p <= i; p++)
				{
					VisualBloc tmp = carte[p, j];
					Bloc bloc = grid[p, j];
					
					if (bloc.rotate != direction)
					{
						if (bloc.rotate == 2)
						{
							tmp.transform.Translate(-5 * Time.deltaTime,0,0);
						}
						else if (bloc.rotate == 3)
						{
							tmp.transform.Translate(0, 0,5 * Time.deltaTime);
						}
						else if (bloc.rotate == 1)
						{
							tmp.transform.Translate(0, 0, -5 * Time.deltaTime);
						}
					}
					else
					{
						tmp.transform.Translate(5*Time.deltaTime,0,0);
					}
				}
				//Changebloc(j,i,4);
			}
		}
	
	public void dico(string colone, string direction)
	{
		char test = colone[0];
		test = Char.ToLower(test);
		if(test >= '0' && test <= '7')
		{
			int i = test -48;
			if (direction == "bas")
			{
				PushBloc(i, 8,1);
			}
			else if (direction == "haut")
			{
				PushBloc(i, 8,3);
			}
			else
			{
				Console.WriteLine("La direction n'est pas haut ou bas");
			}
		}
		else if(test >= 'a' && test <= 'i')
		{
			int j = test -97;
			if (direction == "gauche")
			{
				PushBloc(8,j,2);
			}
			else if (direction == "droite")
			{
				PushBloc(8,j,4);
			}
			else
			{
				Console.WriteLine("La direction n'est pas gauche ou droite");
			}
		}
		else
		{
			Console.WriteLine("La colonne/ligne n'est pas comprise entre 0-7 / A-I");
		}
	}

	void Changebloc(int j, int i, int direction)
	{
		if (direction == 1)
		{
			for (int p = j - 1; p <= 1; p--)
			{
				grid[i, p] = grid[i, p - 1];
			}
			
			
		}
		else if (direction == 2)
		{
			for (int p = 0; p <= j - 1; p++)
			{
				grid[i, p] = grid[i, p + 1];
			}
			
			
		}
		else if (direction == 3)
		{
			for (int p = 1; p <= i-1; p++)
			{
				grid[p,j] = grid[p+1,j];
			}
			
		}
		else if (direction == 4)
		{
			for (int p = j; p >= 1; p--)
			{
				grid[i, p] = grid[i, p - 1];
			}
			
		}
	}
	
//##################################################################################################################################################################################
//               BLOCS DES JOUEURS

	void creation(int i, int j)
	{
		/*grid[i,j] = new Bloc();
		grid[j, i].xpos = j;
		grid[j, i].zpos = i;*/
		Bloc bloc = grid[i, j];
				
		visualBlocInit = Instantiate(visualprefabbloc, new Vector3(bloc.xpos * 20, 0, (height - bloc.zpos)* 20), Quaternion.identity) as VisualBloc;

		carte[i, j] = visualBlocInit;
		int t = 0;
		while (t<bloc.rotate)
		{
			visualBlocInit.transform.Rotate(Vector3.back + new Vector3(0, -90, 0));
			t++;
		}
				
		visualBlocInit.transform.parent = transform;
		visualBlocInit._One.gameObject.SetActive(bloc.type1);
		visualBlocInit._Two.gameObject.SetActive(bloc.type2);
		visualBlocInit._Three.gameObject.SetActive(bloc.type3);
		visualBlocInit._West.gameObject.SetActive(!bloc.type1 && !bloc.type2 && !bloc.type3);
		visualBlocInit._Est.gameObject.SetActive(!bloc.type1 && !bloc.type2);
		visualBlocInit._South.gameObject.SetActive(!bloc.type2 && !bloc.type3);
		visualBlocInit.transform.name = bloc.xpos + "_" + bloc.zpos;
	}
	
	

	void ajout_Bloc(string colone, string direction)
	{
		char test = colone[0];
		test = Char.ToLower(test);
		if (test >= '0' && test <= '7')
		{
			int i = test - 48;
			if (direction == "bas")
			{
				creation(i,0);
			}
			else if (direction == "haut")
			{
				creation(i,8);
			}
		}
		else if (test >= 'a' && test <= 'i')
		{
			int j = test - 97;
			if (direction == "gauche")
			{
				creation(8,j);
			}
			else if (direction == "droite")
			{
				creation(0,j);
			}
		}
	}

}
