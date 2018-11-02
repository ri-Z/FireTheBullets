using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterAIToBase : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform Base;

    void Start()
    {
        Base = GameObject.FindGameObjectWithTag("Base").transform;

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        //Enemy movement em relacao a base
        if (Vector2.Distance(transform.position, Base.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Base.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, Base.position) < stoppingDistance && Vector2.Distance(transform.position, Base.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, Base.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Base.position, -speed * Time.deltaTime);
        }

        //Enemy Shots
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
