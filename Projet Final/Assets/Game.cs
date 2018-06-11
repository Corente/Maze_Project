using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Networking;

public class Game : MonoBehaviour
{
	public bool debut;

	private bool TourDuJoueur1 = true;
	private bool TourDuJoueur2;
	private bool TourDuJoueur3;
	private bool TourDuJoueur4;

	public int NombreDeJoueur = 0;

	public bool Tour1 = true;

	private GameObject Joueur1;
	private GameObject Joueur2;
	private GameObject Joueur3;
	private GameObject Joueur4;

	public int ScoreMax;

	public float Timer = 0;
	private bool depart = false;

	private bool bouton = false;

	private string ligne;
	private string direction;

	public GameObject Grid;

	private bool vasi = false;

	public Bloc[,] grid;
	
	




	void Start()
	{
		grid = Grid.GetComponent<Maze>().grid;
		debut = false;
		
	}


	void Update()
	{
		if (debut)
		{
			Grid.GetComponent<Maze>().enabled = true;
			//Trouver le Nombre de Joueurs
			if (Tour1)
			{
				GameObject[] liste = GameObject.FindGameObjectsWithTag("Player");
				Debug.Log(liste.Length);
				foreach (GameObject p in liste)
				{
					NombreDeJoueur++;
					if (NombreDeJoueur == 1)
					{
						Joueur1 = p;
					}
					else if (NombreDeJoueur == 2)
					{
						Joueur2 = p;
					}
					else if (NombreDeJoueur == 3)
					{
						Joueur3 = p;
					}
					else if (NombreDeJoueur == 4)
					{
						Joueur4 = p;
					}
				}
				Tour1 = false;
			}




			//Gestion Des Tours
			if (NombreDeJoueur == 1)
			{
				if (TourDuJoueur1)
				{
					if (Joueur1.GetComponent<Player>().Score() >= ScoreMax)
					{
						debut = false;
					}
					else if (Joueur1.GetComponent<Variables_texte>().ok)
					{
						
						bouton = false;
						ligne = Joueur1.GetComponent<Variables_texte>().GetLigne();
						direction = Joueur1.GetComponent<Variables_texte>().GetDirection();
					
						Grid.GetComponent<Maze>().Bouge(direction, ligne);

						Joueur1.GetComponentsInChildren<Canvas>()[0].enabled = false;

						Joueur1.GetComponent<CameraFollow>().TourVrai();
						Joueur1.GetComponent<Variables_texte>().ok = false;
						vasi = true;
					}
					else if (!depart && vasi)
					{
						Timer = 30;
						depart = true;
						Joueur1.GetComponent<AficheTemps>().ActiveCanvas();
					}
					else if (Timer > 0 && vasi)
					{
						Timer = Timer - Time.deltaTime;
						Joueur1.GetComponent<AficheTemps>().MettreTemps(Timer.ToString());
						Debug.Log(Timer);
					}
					else if (Timer <= 0 && vasi)
					{
						Debug.Log("Test");
						Joueur1.GetComponent<AficheTemps>().DesactiveCanavs();
						Joueur1.GetComponent<CameraFollow>().TourFalse();
						depart = false;
						vasi = false;
					}
					else
					{
						
						Joueur1.GetComponentsInChildren<Canvas>()[0].enabled = true;
					}
				}
			}
			else if (NombreDeJoueur == 2)
			{
				/*if (TourDuJoueur1)
				{
					if (Joueur1.GetComponent<Player>().Score() >= ScoreMax)
					{
						debut = false;
					}
					else if (Joueur1.GetComponent<Variables_texte>().ok)
					{
						Debug.Log("bugger");
						bouton = false;
						ligne = Joueur2.GetComponent<Variables_texte>().GetLigne();
						direction = Joueur2.GetComponent<Variables_texte>().GetDirection();
					
						Grid.GetComponent<Maze>().Bouge(direction, ligne);

						Joueur2.GetComponentsInChildren<Canvas>()[0].enabled = false;

						Joueur2.GetComponent<CameraFollow>().TourVrai();
						Joueur2.GetComponent<Variables_texte>().ok = false;
						vasi = true;
					}
					else if (!depart && vasi)
					{
						Timer = 30;
						depart = true;
						Joueur1.GetComponent<AficheTemps>().ActiveCanvas();
					}
					else if (Timer > 0 && vasi)
					{
						Joueur1.GetComponent<AficheTemps>().MettreTemps(Timer.ToString());
						Timer -= (int)Time.deltaTime;
						Debug.Log(Timer);
					}
					else if (Timer <= 0 && vasi)
					{
						Joueur1.GetComponent<AficheTemps>().DesactiveCanavs();
						Joueur1.GetComponent<CameraFollow>().TourFalse();
						depart = false;
						vasi = false;
						TourDuJoueur1 = false;
						TourDuJoueur2 = true;
					}
					else
					{
						Debug.Log("Affiche toi");
						Joueur1.GetComponentsInChildren<Canvas>()[0].enabled = true;
					}
				}
				else if (TourDuJoueur2)
				{
					if (Joueur2.GetComponent<Player>().Score() >= ScoreMax)
					{
						debut = false;
					}
					else if (Joueur2.GetComponent<Variables_texte>().ok)
					{
						Debug.Log("bugger");
						bouton = false;
						ligne = Joueur2.GetComponent<Variables_texte>().GetLigne();
						direction = Joueur2.GetComponent<Variables_texte>().GetDirection();
					
						Grid.GetComponent<Maze>().Bouge(direction, ligne);

						Joueur2.GetComponentsInChildren<Canvas>()[0].enabled = false;

						Joueur2.GetComponent<CameraFollow>().TourVrai();
						Joueur2.GetComponent<Variables_texte>().ok = false;
						vasi = true;
					}
					else if (!depart && vasi)
					{
						Timer = 30;
						depart = true;
						Joueur2.GetComponent<AficheTemps>().ActiveCanvas();
					}
					else if (Timer > 0 && vasi)
					{
						Joueur2.GetComponent<AficheTemps>().MettreTemps(Timer.ToString());
						Timer -= (int)Time.deltaTime;
						Debug.Log(Timer);
					}
					else if (Timer <= 0 && vasi)
					{
						Joueur2.GetComponent<AficheTemps>().DesactiveCanavs();
						Joueur2.GetComponent<CameraFollow>().TourFalse();
						depart = false;
						vasi = false;
						TourDuJoueur2 = false;
						TourDuJoueur1 = true;
					}
					else
					{
						Debug.Log("Affiche toi");
						Joueur2.GetComponentsInChildren<Canvas>()[0].enabled = true;
					}
				}*/
				
				Joueur1.GetComponent<CameraFollow>().TourVrai();
				Joueur2.GetComponent<CameraFollow>().TourVrai();
				Joueur1.GetComponent<AficheTemps>().ActiveCanvas();
				Joueur2.GetComponent<AficheTemps>().ActiveCanvas();
				
				
			}
			
			}
			else if (NombreDeJoueur == 3)
			{
				if (Joueur1.GetComponent<Player>().Score() >= ScoreMax)
				{
					debut = false;

				}
				else if (Joueur2.GetComponent<Player>().Score() >= ScoreMax)
				{
					debut = false;
				}
				else if (Joueur3.GetComponent<Player>().Score() >= ScoreMax)
				{
					debut = false;
				}


				else if (TourDuJoueur1)
				{
					//Faire Bouger Les blocs

					//Creer Un timer

					/*if(timer == fini)
					 * {
					 *  	Joueur1.GetComponent<CameraFollow>().TourFaux();
					 * }
					 */

					TourDuJoueur1 = false;
					TourDuJoueur2 = true;
				}
				else if (TourDuJoueur2)
				{
					//Faire Bouger Les blocs
					//Creer Un timer
					Joueur2.GetComponent<CameraFollow>().TourVrai();

					/*if(timer == fini)
					 * {
					 *  	Joueur2.GetComponent<CameraFollow>().TourFaux();
					 * }
					 */

					TourDuJoueur2 = false;
					TourDuJoueur3 = true;
				}
				else if (TourDuJoueur3)
				{
					//Faire Bouger Les blocs
					//Creer Un timer
					Joueur3.GetComponent<CameraFollow>().TourVrai();

					/*if(timer == fini)
					 * {
					 *  	Joueur3.GetComponent<CameraFollow>().TourFaux();
					 * }
					 */

					TourDuJoueur3 = false;
					TourDuJoueur1 = true;
				}
			}
			else if (NombreDeJoueur == 4)
			{
				if (Joueur1.GetComponent<Player>().Score() >= ScoreMax)
				{
					debut = false;

				}
				else if (Joueur2.GetComponent<Player>().Score() >= ScoreMax)
				{
					debut = false;
				}
				else if (Joueur3.GetComponent<Player>().Score() >= ScoreMax)
				{
					debut = false;
				}
				else if (Joueur4.GetComponent<Player>().Score() >= ScoreMax)
				{
					debut = false;
				}


				else if (TourDuJoueur1)
				{
					//Faire Bouger Les blocs
					//Creer Un timer
					Joueur1.GetComponent<CameraFollow>().TourVrai();

					/*if(timer == fini)
					 * {
					 *  	Joueur1.GetComponent<CameraFollow>().TourFaux();
					 * }
					 */

					TourDuJoueur1 = false;
					TourDuJoueur2 = true;
				}
				else if (TourDuJoueur2)
				{
					//Faire Bouger Les blocs
					//Creer Un timer
					Joueur2.GetComponent<CameraFollow>().TourVrai();

					/*if(timer == fini)
					 * {
					 *  	Joueur2.GetComponent<CameraFollow>().TourFaux();
					 * }
					 */

					TourDuJoueur2 = false;
					TourDuJoueur3 = true;
				}
				else if (TourDuJoueur3)
				{
					//Faire Bouger Les blocs
					//Creer Un timer
					Joueur3.GetComponent<CameraFollow>().TourVrai();

					/*if(timer == fini)
					 * {
					 *  	Joueur3.GetComponent<CameraFollow>().TourFaux();
					 * }
					 */

					TourDuJoueur3 = false;
					TourDuJoueur4 = true;
				}
				else if (TourDuJoueur4)
				{
					//Faire Bouger Les blocs
					//Creer Un timer
					Joueur4.GetComponent<CameraFollow>().TourVrai();

					/*if(timer == fini)
					 * {
					 *  	Joueur3.GetComponent<CameraFollow>().TourFaux();
					 * }
					 */

					TourDuJoueur4 = false;
					TourDuJoueur1 = true;
				}
			}
		}
	
	public void gogogogo()
	{
		debut = true;
	}
	
}

	


