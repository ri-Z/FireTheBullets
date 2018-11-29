using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIShooterToBase : MonoBehaviour{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform Base;

    private Vector2 currentEnemy;

    void Start()
    {
        Base = GameObject.FindGameObjectWithTag("Base").transform;

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        //Enemy movement em relacao a base
        float baseTDistance = Vector2.Distance(transform.position, Base.position);

        if (baseTDistance > stoppingDistance)
            transform.position = Vector2.MoveTowards(transform.position, Base.position, speed * Time.deltaTime);
        else if (baseTDistance < retreatDistance)
            transform.position = Vector2.MoveTowards(transform.position, Base.position, -speed * Time.deltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, Base.position, speed * Time.deltaTime);
        currentEnemy = new Vector2(Base.position.x, Base.position.y);

        //Enemy Shots
        if (timeBtwShots <= 0)
        {
            EnemyBullet bullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<EnemyBullet>();
            bullet.SetTarget(currentEnemy);

            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
