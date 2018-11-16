using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] towerPrefabs;

    //private Collider2D Player;
    public Collider2D[] colliders;

    void Start () {
        //Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        colliders = gameObject.GetComponentsInChildren<Collider2D>();
    }

    void Update () {

    }

    public void spawn(Transform location)
    {
        int i = 0;

        while (spawnLocations[i] != location)
            ++i;

        Instantiate(towerPrefabs[i], spawnLocations[i].transform.position, Quaternion.Euler(0, 0, 0));
    }

    public void collisionDetected(TowerCreate towerCreate){
        //Debug.Log("child collided (parent)");
    }
}
