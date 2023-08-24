using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour {

    public List<GameObject> Modules = new List<GameObject>();

    private List<GameObject> SpawnPoints = new List<GameObject>();

    private List<GameObject> MazeModules = new List<GameObject>();
	// Use this for initialization
	void Start () {
        SpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("ModuleLoc"));

        foreach (GameObject SpawnPoint in SpawnPoints)
        {
            MazeModules.Add(Instantiate(Modules[Random.Range(0, Modules.Count)], SpawnPoint.transform.position, Quaternion.identity));
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Vérification de la bonne position des éléments du Maze
		//TODO : en faire une fonction
		
		//Préparation des variables
		bool checkPosition = false;
		bool checkRotation = false;
		
		//Boucle sur les modules du maze
		for (int i = 0; i < GameObject.FindGameObjectsWithTag("MazeModule").Length; i++)
		{
			//on remets les variables de test à false
			checkPosition = false;
			checkRotation = false;
			
			// on boucle sur chaque spawnPoints
			for (int j = 0; j < SpawnPoints.Count; j++)
			{
				// on compare la posiiton du spawnPoint à la position du module
				// on utilise Vector3.distance pour avoir une sécurité par rapport aux erreurs de virgules flottantes d'unity
				if (Vector3.Distance(SpawnPoints[j].transform.position,GameObject.FindGameObjectsWithTag("MazeModule")[i].transform.position) <= 0.01f)
				{
					// on mets la la variable de test de position à vrai vu que l'écart de distance est acceptable
					checkPosition = true;
					// on utilise Quaternion.Angle pour avoir une sécurité par rapport aux erreurs de virgules flottantes d'unity
					if (Quaternion.Angle(SpawnPoints[j].transform.rotation, GameObject.FindGameObjectsWithTag("MazeModule")[i].transform.rotation) <= 0.01f)
					{
						// on mets la la variable de test de rotation à vrai vu que l'écart d'angle est acceptable
						checkRotation = true;
					}
					// on arrete la boucle vu qu'au moins la position est bonne, pas la peine d'aller plus loin, on économise de la mémoire et du temps CPU
					break;
				}
			}
			// en fonction du resultat du test de position, on prévient l'intégrateur d'un soucis sur le module.
			if (!checkPosition)
			{
				Debug.Log("Module mal placé, il a bougé il faut vérifier !!!");
			}
			else
			{
				Debug.Log("Module bien placé !!");
			}
			// en fonction du resultat du test de Rotation, on prévient l'intégrateur d'un soucis sur le module.
			if (!checkRotation)
			{
				Debug.Log("Module mal orienté, il a bougé il faut vérifier !!!");
			}
			else
			{
				Debug.Log("Module bien orienté !!");
			}
		}
	}
}
