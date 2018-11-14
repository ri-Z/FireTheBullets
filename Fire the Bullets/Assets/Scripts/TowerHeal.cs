﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHeal : MonoBehaviour
{
    public float timeBtwShots = 200f;
    private Transform target;

    [Header("Attributes")]
    public float range = 7f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string tagerino = "Enemy";
    public GameObject towerBullet;
    public Transform firePoint;
    private bool isFirstBullet = true;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }


        if (fireCountdown <= 0f)
        {
            if (isFirstBullet)
            {
                if (timeBtwShots <= 0)
                {
                    timeBtwShots -= Time.deltaTime;
                }
                isFirstBullet = false;
            }
            else
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }

        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tagerino);

        float shortestDistance = Mathf.Infinity;
        GameObject closest = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                closest = enemy;
            }
        }

        if (closest != null && shortestDistance <= range)
        {
            target = closest.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(towerBullet, firePoint.position, Quaternion.identity);
        TowerHealer bullet = bulletGo.GetComponent<TowerHealer>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}
