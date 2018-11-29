using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public Transform playerSpawnPoint;
    public GameObject playerPrefab;
    public Player player;

    public Transform baseSpawnPoint;
    public GameObject basePrefab;
    public Base baseObject;

    public Transform HealthBarPrefab;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }

        GameSetup();
    }

    private void GameSetup()
    {
        SpawnPlayer();
        SpawnBase();
    }

    void SpawnPlayer()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
        Player player = playerGO.GetComponent<Player>();

        this.player = player;
    }

    void SpawnBase(){
        GameObject baseGO = Instantiate(basePrefab, baseSpawnPoint.position, Quaternion.identity);
        Base baseObject = baseGO.GetComponent<Base>();

        this.baseObject = baseObject;
    }
}
