﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed;
	public float damage;
    private Vector2 target;

    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = new Vector3(target.x, target.y, 0) - transform.position;//lookAt() but in 2D
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.position += transform.right * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, GameManager.instance.player.transform.position) >= 20f)
        {
            DestroyProjectile();
        }

        //if x and y coordinates are equal to the target's coordinates
        //if (transform.position.x == target.x && transform.position.y == target.y)
        //{
        //    DestroyProjectile();
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Bullet"))
        {
            DestroyProjectile();
            
			if (collision.CompareTag("Enemy"))
            {
				collision.GetComponent<Enemy>().Hit(damage);
            }
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
