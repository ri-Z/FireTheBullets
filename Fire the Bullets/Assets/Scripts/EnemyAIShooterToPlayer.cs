using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIShooterToPlayer : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;
    private Transform baseT;
    public float priorityBaseDistance;


    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        baseT = GameObject.FindGameObjectWithTag("Base").transform;

        timeBtwShots = startTimeBtwShots;
    }
	
	void Update () {

        Vector2 currentEnemy;
        float baseTDistance = Vector2.Distance(transform.position, baseT.position);
        if (baseTDistance <= priorityBaseDistance)
        {
            if (baseTDistance > stoppingDistance)
                transform.position = Vector2.MoveTowards(transform.position, baseT.position, speed * Time.deltaTime);
            else if (baseTDistance < retreatDistance)
                transform.position = Vector2.MoveTowards(transform.position, baseT.position, -speed * Time.deltaTime);

            transform.position = Vector2.MoveTowards(transform.position, baseT.position, speed * Time.deltaTime);
            currentEnemy = new Vector2(baseT.position.x, baseT.position.y);
        }
        else
        {
            float playerDistance = Vector2.Distance(transform.position, player.position);

            if (playerDistance > stoppingDistance)
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            else if (playerDistance < retreatDistance)
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

            currentEnemy = new Vector2(player.position.x, player.position.y);
        }


        //    //Enemy movement em relacao ao player
        //    if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        //{
        //    transform.position = this.transform.position;
        //}else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //}
        //else if (Vector2.Distance(transform.position, baseT.position) > stoppingDistanceBase)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}

        //Enemy Shots time between them
        if (timeBtwShots <= 0)
        {
            EnemyBullet bullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<EnemyBullet>();
            bullet.SetTarget(currentEnemy);

            timeBtwShots = startTimeBtwShots;
        }else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
