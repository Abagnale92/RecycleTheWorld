using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunnezzaSpawnerControl : MonoBehaviour {

    // Use this for initialization
    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int randomSpawnPoint, randomMonster;
    public static bool spawnAllowed;

    public GameObject[] trash;
    int randomTrash;
    public Transform spawnTrash;
   

	void Start () {
        spawnAllowed = true;
        InvokeRepeating("SpawnAMonster", 0f, 1f);
        SpawnTrash();
	}
	
	// Update is called once per frame
	void SpawnAMonster () {
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomMonster = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonster], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
		
	}

    void SpawnTrash()
    {
        randomTrash = Random.Range(0, trash.Length);
        Instantiate(trash[randomTrash], spawnTrash.position, Quaternion.identity);
        trash[randomTrash].gameObject.SetActive(true);
        
    }
}

