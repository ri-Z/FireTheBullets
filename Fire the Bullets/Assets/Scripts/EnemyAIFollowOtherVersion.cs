using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIFollowOtherVersion : MonoBehaviour {

    public float speed;
    public float stoppingDistance;

    private Transform targetPlayer;
    //private Transform targetBase;

    void Start () {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //targetBase = GameObject.FindGameObjectWithTag("Base").GetComponent<Transform>();
    }

    void Update () {
        if (Vector2.Distance(transform.position, targetPlayer.position) > stoppingDistance){
            transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
        }
        //else{
        //    transform.position = Vector2.MoveTowards(transform.position, targetBase.position, speed * Time.deltaTime);
        //}
    }
}
