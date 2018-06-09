using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MalusBonus : MonoBehaviour 
{

	
	protected GameObject artefact1;
	protected GameObject artefact2;
	protected GameObject artefact3;
	protected GameObject artefact4;

	protected GameObject player;

	public GameObject Grid;

	public GameObject end;

	public enum State
	{
		NO,
		MALUS,
		BONUS
	}

	public State WinQTE;
	
	private  Bloc[,] grid;

	public char[][] drawGrid;
	public int[][] processed;

	public Point positionPlayer;

	public int bonusTemps;

	private void Start()
	{
		grid = Grid.GetComponent<Maze>().grid;
		WinQTE = State.NO;
		drawGrid = ToList(DrawWays());
		processed = new int[27][];
		for (int i = 0; i < 27; i++)
		{
			processed[i] = new int[27];
			for (int j = 0; j < 27; j++)
				processed[i][j] = 0;
		}
		positionPlayer = new Point((int) player.transform.position.x / 20, (int) (player.transform.position.z + 1) / 20);
		bonusTemps = 0;
		Debug.Log("player x : " + positionPlayer.X + "player y : " + positionPlayer.Y);
	}

	private void Update()
	{
		if (end.GetComponent<End>().finished)
		{
			if (end.GetComponent<End>().winning)
			{
				WinQTE = State.BONUS;
			}
			else
			{
				WinQTE = State.MALUS;
			}
		}
		else
		{
			WinQTE = State.NO;
		}
		Attribute();
	}


	public void Attribute()
	{
		if (WinQTE == State.BONUS)
		{
			Bonus();
		}
		else if (WinQTE == State.MALUS)
		{
			Malus();
		}
	}

	public void Bonus()
	{
		if (SolveMazeBackTracking(drawGrid, processed, positionPlayer))
		{
			Debug.Log("You can go to the artefact");
			for (int i = 1; i < 27; i += 3)
			{
				for (int j = 1; j < 27; j += 3)
				{
					if (drawGrid[i][j] == 'P')
					{
						grid[i /3, j/3].particule.GetComponentInChildren<ParticleSystem>().Play();
					}
				}
			}
		}
		else
		{
			Debug.Log("You can't access an artefact");
			bonusTemps = 20;
		}
	}

	public void Malus()
	{
		bonusTemps = -20;
	}

	
//############################################################################################################################################################################
//                         Draw the labyrinthe
	
	public string DrawWays()
	{
		string ways = "";
		for (int i = 0; i < grid.GetLength(0); i++)
		{
			string line1 = "";
			string line2 = "";
			string line3 = "";
			for (int j = 0; j < grid.GetLength(1); j++)
			{
				int rotation = grid[i, j].rotate;
				bool findArtefact = grid[j, i].AMB == artefact1 || grid[j, i].AMB == artefact2 || grid[j, i].AMB == artefact3 ||
				                    grid[j, i].AMB == artefact4;
				if (grid[i, j].type == "I")
				{
					line1 += BlocI(rotation, findArtefact)[0];
					line2 += BlocI(rotation, findArtefact)[1];
					line3 += BlocI(rotation, findArtefact)[2];
				}
				else if (grid[i, j].type == "L")
				{
					line1 += BlocL(rotation, findArtefact)[0];
					line2 += BlocL(rotation, findArtefact)[1];
					line3 += BlocL(rotation, findArtefact)[2];
				}
				else
				{
					line1 += BlocT(rotation, findArtefact)[0];
					line2 += BlocT(rotation, findArtefact)[1];
					line3 += BlocT(rotation, findArtefact)[2];
				}
			}
			ways += line1 + "\n" + line2 + "\n" + line3 + "\n";
		}
		return ways;
	}

	public string[] BlocI(int rotation, bool findArtefact)
	{
		string[] blocI = new string[3];
		if (rotation == 2 || rotation == 4)
		{
			blocI[0] = "M_M";
			if (findArtefact)
			{
				blocI[1] = "MAM";
			}
			else
			{
				blocI[1] = "M_M";
			}
			blocI[2] = "M_M";
		}
		else if (rotation == 1 || rotation == 3)
		{
			blocI[0] = "MMM";
			
			if (findArtefact)
			{
				blocI[1] = "_A_";
			}
			else
			{
				blocI[1] = "___";
			}
			blocI[2] = "MMM";
		}
		return blocI;
	}

	public string[] BlocL(int rotation, bool findArtefact)
	{
		string[] blocL = new string[3];
		if (rotation == 1)
		{
			blocL[0] = "MMM";
			if (findArtefact)
			{
				blocL[1] = "MA_";
			}
			else
			{
				blocL[1] = "M__";
			}
			blocL[2] = "M_M";
		}
		else if (rotation == 2)
		{
			blocL[0] = "M_M";
			if (findArtefact)
			{
				blocL[1] = "MA_";
			}
			else
			{
				blocL[1] = "M__";
			}
			blocL[2] = "MMM";
		}
		else if (rotation == 3)
		{
			blocL[0] = "M_M";
			if (findArtefact)
			{
				blocL[1] = "_AM";
			}
			else
			{
				blocL[1] = "__M";
			}
			blocL[2] = "MMM";
		}
		else
		{
			blocL[0] = "MMM";
			if (findArtefact)
			{
				blocL[1] = "_AM";
			}
			else
			{
				blocL[1] = "__M";
			}
			blocL[2] = "M_M";
		}
		return blocL;
	}

	public string[] BlocT(int rotation, bool findArtefact)
	{
		string[] blocT = new string[3];
		if (rotation == 1)
		{
			blocT[0] = "MMM";
			if (findArtefact)
			{
				blocT[1] = "_A_";
			}
			else
			{
				blocT[1] = "___";
			}
			blocT[1] = "M_M";
		}
		else if (rotation == 2)
		{
			blocT[0] = "M_M";
			if (findArtefact)
			{
				blocT[1] = "MA_";
			}
			else
			{
				blocT[1] = "M__";
			}
			blocT[2] = "M_M";
		}
		else if (rotation == 3)
		{
			blocT[0] = "M_M";
			if (findArtefact)
			{
				blocT[1] = "_A_";
			}
			else
			{
				blocT[1] = "___";
			}
			blocT[2] = "MMM";
		}
		else
		{
			blocT[0] = "M_M";
			if (findArtefact)
			{
				blocT[1] = "_AM";
			}
			else
			{
				blocT[1] = "__M";
			}
			blocT[2] = "M_M";
		}
		return blocT;
	}

	public char[][] ToList(string str)
	{
		int i = 0;
		int x = 0;
		int y = 0;
		int length = str.Length;
		char[][] output = new char[27][];
		while (i < length)
		{
			output[y] = new char[27];
			x = 0;
			while (str[i] != '\n')
			{
				output[y][x] = str[i];
				i++;
				x++;
			}
			y++;
			i++;
		}
		return output;
	}

//############################################################################################################################################################################
//                         Solve the labyrinthe
	
	
	private static bool SolveMazeBackTracking(char[][] grid, int[][] processed, Point p)
	{
		if (p.X < 0 || p.X >= grid.Length)
			return false;
		if (p.Y < 0 || p.Y >= grid[0].Length)
			return false;

		if (processed[p.X][p.Y] != 0)
			return false;
		processed[p.X][p.Y] = 1;

		if (grid[p.X][p.Y] == 'F')
			return true;
		if (grid[p.X][p.Y] == 'M')
			return false;

		if (SolveMazeBackTracking(grid, processed, new Point(p.X - 1, p.Y)))
			grid[p.X][p.Y] = 'P';
		else if (SolveMazeBackTracking(grid, processed, new Point(p.X, p.Y - 1)))
			grid[p.X][p.Y] = 'P';
		else if (SolveMazeBackTracking(grid, processed, new Point(p.X, p.Y + 1)))
			grid[p.X][p.Y] = 'P';
		else if (SolveMazeBackTracking(grid, processed, new Point(p.X + 1, p.Y)))
			grid[p.X][p.Y] = 'P';

		return grid[p.X][p.Y] == 'P';
	}
	

	
	
//############################################################################################################################################################################
//                         Class Point
	
	public class Point
	{
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int Y { get; set; }
		public int X { get; set; }
	}
	
}
