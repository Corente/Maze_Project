using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Networking;

public class Game : NetworkBehaviour
{
	public bool debut;
	
	private bool TourDuJoueur1;
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

	public int Timer = 0;
	private int depart =0;

	private bool bouton = false;

	private string ligne;
	private string direction;

	public GameObject Grid;

	
	
	
	
	void Start ()
	{
		debut = false;
	}
	
	
	void Update () 
	{
		if (debut)
		{
			//Mettre Fin
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
			
			//Trouver le Nombre de Joueurs
			if (Tour1)
			{
				GameObject[] liste = GameObject.FindGameObjectsWithTag("Player");
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
				if (bouton)
				{
					bouton = false;
					ligne = Joueur1.GetComponent<Variables_texte>().GetLigne();
					direction = Joueur1.GetComponent<Variables_texte>().GetDirection();
					
					Grid.GetComponent<Maze>().Bouge(direction,ligne);
					
					Joueur1.GetComponent<Canvas>().enabled = true;
					
					Joueur1.GetComponent<CameraFollow>().TourVrai();
				}
				else if (depart == 0)
				{
					Timer = 30;
					depart = (int)Time.deltaTime;
				}
				else if (Timer > 0)
				{
					Joueur1.GetComponent<AficheTemps>().MettreTemps(Timer.ToString());
					Timer = Timer - (depart - (int)Time.deltaTime);
				}
				else if (Timer <= 0)
				{
					Joueur1.GetComponent<CameraFollow>().TourFalse();
					TourDuJoueur1 = false;
					TourDuJoueur2 = true;
				}
				else
				{
					Joueur1.GetComponent<Canvas>().enabled = true;
				}
			}
			if (NombreDeJoueur == 2)
			{
				if (TourDuJoueur1)
				{
					/*
					 * Ici on active le canvas afin que le joueur puisse choisir sa ligne / colone à bouger
					 * Puis tant qu'il a pas appuyer sur le bouton on attend
					 * On remet le bouton a false
					 * On prend en compte les infos qu'il a entré
					 * On bouge les Blocs
					 * On Desactive son Canvas
					 * On lui chnage la cam
					 */
					if (bouton)
					{
						bouton = false;
						ligne = Joueur1.GetComponent<Variables_texte>().GetLigne();
						direction = Joueur1.GetComponent<Variables_texte>().GetDirection();
					
						Grid.GetComponent<Maze>().Bouge(direction,ligne);
					
						Joueur1.GetComponent<Canvas>().enabled = true;
					
						Joueur1.GetComponent<CameraFollow>().TourVrai();
					}
					else if (depart == 0)
					{
						Timer = 30;
						depart = (int)Time.deltaTime;
					}
					else if (Timer > 0)
					{
						Joueur1.GetComponent<AficheTemps>().MettreTemps(Timer.ToString());
						Timer = Timer - (depart - (int)Time.deltaTime);
					}
					else if (Timer <= 0)
					{
						Joueur1.GetComponent<CameraFollow>().TourFalse();
						TourDuJoueur1 = false;
						TourDuJoueur2 = true;
					}
					else
					{
						Joueur1.GetComponent<Canvas>().enabled = true;
					}
				}
				else if (TourDuJoueur2)
				{
					if (bouton)
					{
						bouton = false;
						ligne = Joueur2.GetComponent<Variables_texte>().GetLigne();
						direction = Joueur2.GetComponent<Variables_texte>().GetDirection();
					
						Grid.GetComponent<Maze>().Bouge(direction,ligne);
					
						Joueur2.GetComponent<Canvas>().enabled = true;
					
						Joueur2.GetComponent<CameraFollow>().TourVrai();
					}
					else if (depart == 0)
					{
						Timer = 30;
						depart = (int)Time.deltaTime;
					}
					else if (Timer > 0)
					{
						Joueur2.GetComponent<AficheTemps>().MettreTemps(Timer.ToString());
						Timer = Timer - (depart - (int)Time.deltaTime);
					}
					else if (Timer <= 0)
					{
						Joueur2.GetComponent<CameraFollow>().TourFalse();
						TourDuJoueur2 = false;
						TourDuJoueur1 = true;
					}
					else
					{
						Joueur2.GetComponent<Canvas>().enabled = true;
					}
				}
			}
			if (NombreDeJoueur == 3)
			{
				if (TourDuJoueur1)
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
			if (NombreDeJoueur == 4)
			{
				if (TourDuJoueur1)
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
	}

	public void gogogogo()
	{
		debut = true;
	}

	public void Clicked()
	{
		bouton = true;
	}
}
