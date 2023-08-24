using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> EnemyPrefabs;
    
    void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("EnemySpawnPoint").Length; i++)
        {
            Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)],
                GameObject.FindGameObjectsWithTag("EnemySpawnPoint")[i].transform.position,
                GameObject.FindGameObjectsWithTag("EnemySpawnPoint")[i].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // vérification si un enemy est mort et le cas échéant en faire spawn un nouveau à une position aléatoire
        // pour cela on compare le nombre théorique d'enemy avec le nombre actuel
        while (GameObject.FindGameObjectsWithTag("EnemySpawnPoint").Length >
               GameObject.FindGameObjectsWithTag("Enemy").Length)
        {
            int RandomNumber = Random.Range(0, EnemyPrefabs.Count);
            Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count)],
                GameObject.FindGameObjectsWithTag("EnemySpawnPoint")[RandomNumber].transform.position,
                GameObject.FindGameObjectsWithTag("EnemySpawnPoint")[RandomNumber].transform.rotation);
        }
    }
}
