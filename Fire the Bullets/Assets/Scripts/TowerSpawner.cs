using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour {

    public Transform[] spawnLocations;
    public GameObject[] towerPrefabs;
    //public GameObject[] whatToSpawnClone;

    //private Collider2D Player;
    public Collider2D[] colliders;

    void Start () {
        //spawn();
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

    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Collider2D[] colliders = gameObject.GetComponentsInChildren<Collider2D>();
    //    foreach (Collider2D collider2D in colliders)
    //    {
    //        if (collider2D.IsTouching(Player))
    //        {
    //            spawn();
    //            collider2D.enabled = false;
    //            //Destroy(collision.gameObject);
    //        }
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //var colliders = gameObject.GetComponentsInChildren<Collider2D>();
    //    //Debug.Log(colliders);
    //    //for (var index = 0; index < colliders.Length; index++)
    //    //{
    //        //var colliderItem = colliders[index];
    //        if (collision.gameObject.tag == "Player")
    //        {
    //            //colliderItem.enabled = false;
    //            Debug.Log("collision");
    //        }
    //    //}
    //}

    public void collisionDetected(TowerCreate towerCreate){
        //Debug.Log("child collided (parent)");
    }
}
