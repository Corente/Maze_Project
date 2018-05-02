using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using Random = UnityEngine.Random;

public class Maze : MonoBehaviour
{

	public int width, height;
	public VisualBloc visualprefabbloc;

	public Bloc[,] grid;
	public VisualBloc[,] carte;

	private Vector2 _randomCellPos;

	private VisualBloc visualBlocInit;

	int[] selection = new int[3];

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	
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
		//PushSelection();
		PushBloc();
		

	}

	void Init()
	{
		for (int j = 0; j < width; j++)
		{
			for (int i = 0; i < height; i++)
			{
				grid[j,i] = new Bloc(/*false, false, false, false*/);
				grid[j, i].xpos = j;
				grid[j, i].zpos = i;
			}
		}
		//Shuffle();
		
		InitVisual();
		
	}

	void Shuffle()
	{
		for (int k = 0; k < 4*width*height; k++)
		{
			int i = Random.Range(0, width);
			int j = Random.Range(0, height);

			if (i % 2 == 1 || j % 2 == 1)
			{
				int i2 = Random.Range(0, width);
				int j2 = Random.Range(0, height);

				while (i2 % 2 == 0 && j2 % 2 == 0)
				{
					i2 = Random.Range(0, width);
					j2 = Random.Range(0, height);
				}

				Bloc tmp = grid[i2, j2];
				grid[i2, j2] = grid[i, j];
				grid[i2, j2].xpos = i;
				grid[i2, j2].zpos = j;
				grid[i, j] = tmp;
				grid[i, j].xpos = i2;
				grid[i, j].zpos = j2;
				
				VisualBloc tmp2 = carte[i2, j2];
				carte[i2, j2] = carte[i, j];
				carte[i, j] = tmp2;
				
			}
		}
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
				//visualBlocInit._dWest.gameObject.SetActive(!bloc.west);

				visualBlocInit.transform.name = bloc.xpos + "_" + bloc.zpos;

				
			}
		}
			
		
	}
	
	
	

	void PushSelection()
	{
		bool selected = false;
		int i = 0, j = 1;
		selection[2] = 1;
		while (!selected)
		{
			
			if (Input.GetKeyDown("space"))
			{
				selection[0] = i;
				selection[1] = j;
				selected = true;
			}
			else
			{
				if (Input.GetKeyDown("up"))
				{
					if (i == 0)
					{
						j+=2;
						selection[2] = 1;
						if (j >= width)
						{
							i = 1;
							j = width - 1;
							selection[2] = 2;
						}
					}
					
					else if (j == width - 1)
					{
						i += 2;
						selection[2] = 2;
						if (i >= height)
						{
							selection[2] = 3;
							i = height - 1;
							j = width - 2;
						}
					}
					else if (j == 0)
					{
						i -= 2;
						selection[2] = 4;
						if (i <= 0)
						{
							selection[2] = 1;
							i = 0;
							j = 1;
						}
					}
					else
					{
						j -= 2;
						selection[2] = 3;
						if (j <= 0)
						{
							selection[2] = 4;
							i = height - 2;
							j = 0;
						}
					}
				}
				if (Input.GetKeyDown("down"))
				{
					//Do something
				}
			}
		}
	}


	void PushBloc()
		{
			//int i = selection[0];
			//int j = selection[1];
			//int direction = selection[2];
			int i = 3;
			int j = 8;
			int direction = 1;
			
		
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
				//Bloc bloc = grid[0, j];
				//Changebloc(j,i,bloc,grid,direction);
				//grid[0, j] = PlayerBloc ;
				//carte[o,j] = playerVisualBloc
				
				
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
					//Bloc bloc = grid[0, j];
					//Changebloc(j,i,bloc,grid,direction);
					//grid[0, j] = PlayerBloc ;
					//carte[o,j] = playerVisualBloc
				}
				
				
				
				
				//Changebloc(j,i,bloc,grid,direction);
				
				//grid[i, j] = bloc;
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
							tmp.transform.Translate(0, 0,5 * Time.deltaTime);
						}
						else if (bloc.rotate == 1)
						{
							tmp.transform.Translate( -5 * Time.deltaTime,0, 0);
						}
						else if (bloc.rotate == 4)
						{
							tmp.transform.Translate( 0, 0,-5 * Time.deltaTime);
						}
					}
					else
					{
						tmp.transform.Translate(5*Time.deltaTime,0,0);
					}
				}
				//Bloc bloc = grid[0, j];
				//Changebloc(j,i,bloc,grid,direction);
				//grid[0, j] = PlayerBloc ;
				//carte[o,j] = playerVisualBloc
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
				//Bloc bloc = grid[0, j];
				//Changebloc(j,i,bloc,grid,direction);
				//grid[0, j] = PlayerBloc ;
				//carte[o,j] = playerVisualBloc
			}
		}

	void Changebloc(int j, int i, Bloc bloc, Bloc[,] map, int direction)
	{
		if (direction == 1)
		{
			for (int p = i - 1; p <= 1; p--)
			{
				map[p, j] = map[p - 1, j];
			}
			
		}
		else if (direction == 2)
		{
			for (int p = j; p >= 1; p--)
			{
				map[i, p] = map[i, p - 1];
			}
			
		}
		else if (direction == 3)
		{
			for (int p = 1; p <= i - 1; p++)
			{
				map[p, j] = map[p + 1, j];
			}
			
		}
		else if (direction == 4)
		{
			for (int p = 1; p <= j - 1; p++)
			{
				map[i, p] = map[i, p + 1];
			}
			
		}
	}


}
