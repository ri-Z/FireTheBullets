using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    //est
    public float initialLife;
    public float currentLife;
    //
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    private int randomSpawnPoint, randomEnemy;
    public static bool spawnAllowed;
    
	void Start () {
        currentLife = initialLife;
        spawnAllowed = true;
        InvokeRepeating("spawning", 1f, 3f);
	}
	
	void Update () {

    }

    void spawning(){
        if (spawnAllowed)
        {
            randomSpawnPoint = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemies.Length);

            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
        }
    }

    public void Hit(float damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
