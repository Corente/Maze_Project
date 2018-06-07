using Boo.Lang;
using UnityEngine;
using UnityEngine.Networking;

public class Multi : NetworkManager
{
	public GameObject Joueur1;
	public GameObject Joueur2;
	public GameObject Joueur3;
	public GameObject Joueur4;

	private int nbrePlayer = 0;

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{

		if (nbrePlayer == 0)
		{
			nbrePlayer++;
			GameObject player = Instantiate(Joueur1, Vector3.zero, Quaternion.identity);
			NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
		}
		if (nbrePlayer == 1)
		{
			nbrePlayer++;
			GameObject player = Instantiate(Joueur2, Vector3.zero, Quaternion.identity);
			NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
		}
		if (nbrePlayer == 2)
		{
			nbrePlayer++;
			GameObject player = Instantiate(Joueur3, Vector3.zero, Quaternion.identity);
			NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
		}
		if (nbrePlayer == 3)
		{
			nbrePlayer++;
			GameObject player = Instantiate(Joueur4, Vector3.zero, Quaternion.identity);
			NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
		}
		
	}
}
