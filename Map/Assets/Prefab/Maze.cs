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

	private Vector2 _randomCellPos;

	private VisualBloc visualBlocInit;

	int[] selection = new int[3];
	
	
	// Use this for initialization
	void Start () {
		grid = new Bloc[width,height];
		Init();
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
		Shuffle();
		
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
				
				grid[i, j] = tmp;
			}
		}
	}

	void InitVisual()
	{
		foreach (Bloc bloc in grid)
		{
			visualBlocInit = Instantiate(visualprefabbloc, new Vector3(bloc.xpos * 20, 0, (height - bloc.zpos)* 20), Quaternion.identity) as VisualBloc;

			while (bloc.rotate > 1)
			{
				visualBlocInit.transform.Rotate(Vector3.back + new Vector3(0, -90, 0));
				bloc.rotate--;
			}
			visualBlocInit.transform.parent = transform;
			visualBlocInit._One.gameObject.SetActive(bloc.type1);
			visualBlocInit._Two.gameObject.SetActive(bloc.type2);
			visualBlocInit._Three.gameObject.SetActive(bloc.type3);
			//visualBlocInit._dWest.gameObject.SetActive(!bloc.west);

			visualBlocInit.transform.name = bloc.xpos + "_" + bloc.zpos;
		}
	}
	// Update is called once per frame
	void Update () {
		
		PushSelection();
		PushBloc();
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
				if (Input.GetButtonDown("up"))
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
				if (Input.GetButtonDown("down"))
				{
					//Do something
				}
			}
		}
	}
	
	void PushBloc()
	{
		int i = selection[0];
		int j = selection[1];
		int direction = selection[2];
		
	}
}
