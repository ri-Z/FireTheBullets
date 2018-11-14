using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float speed;

    //private Transform player;
    private Vector2 target;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = new Vector3(target.x, target.y, 0) - transform.position;//lookAt() but in 2D
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        transform.position += transform.right * speed * Time.deltaTime;

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
                Destroy(gameObject, 2f);
            }
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
