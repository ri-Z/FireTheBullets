using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour {

    //EnemyComponent[] enemyComponent;

    public GameObject[] targets;
    GameObject closest;
    float distance = Mathf.Infinity;
    private EnemyAIFollow target1;
    private EnemyAIShooterToBase target2;
    private EnemyAIShooterToPlayer target3;

    //private Queue<EnemyComponent> enemyComponents = new Queue<EnemyComponent>();
    private Queue<EnemyAIFollow> enemyAIFollows = new Queue<EnemyAIFollow>();
    private Queue<EnemyAIShooterToBase> enemyAIShooterToBase = new Queue<EnemyAIShooterToBase>();
    private Queue<EnemyAIShooterToPlayer> enemyAIShooterToPlayer = new Queue<EnemyAIShooterToPlayer>();

	void Start () {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in targets)
        {
            Vector2 diff = target.transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = target;
                distance = curDistance;
            }
        }
    }
	
	void Update () {
        //Debug.Log(enemies);
        Attack();
        //Debug.Log(target1);
        //Debug.Log(target2);
        //Debug.Log(target3);
	}

    private void Attack(){
        //if (target1 == null && enemyAIFollows.Count > 0)
        //{
        //    target1 = enemyAIFollows.Dequeue();
        //}
        //else if (target2 == null && enemyAIShooterToBase.Count > 0)
        //{
        //    target2 = enemyAIShooterToBase.Dequeue();
        //}
        //else if (target3 == null && enemyAIShooterToPlayer.Count > 0)
        //{
        //    target3 = enemyAIShooterToPlayer.Dequeue();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Enemy")
        //{
        //    enemyAIFollows.Enqueue(collision.GetComponent<EnemyAIFollow>());
        //}
        //else if (collision.tag == "Enemy")
        //{
        //    enemyAIShooterToBase.Enqueue(collision.GetComponent<EnemyAIShooterToBase>());
        //}
        //else if (collision.tag == "Enemy")
        //{
        //    enemyAIShooterToPlayer.Enqueue(collision.GetComponent<EnemyAIShooterToPlayer>());
        //}
        if (collision.tag == "Enemy")
        {
            Debug.Log(closest);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

            //target1 = null;
            //target2 = null;
            //target3 = null;
        }
    }
}
