using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL2Shooter : MonoBehaviour {
    //Goes for the Base

    public float speed;

    private Transform Base;
    private Vector2 target;

    void Start()
    {
        Base = GameObject.FindGameObjectWithTag("Base").transform;

        target = new Vector2(Base.position.x, Base.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if x and y coordinates are equal to the target's coordinates
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Base") || collision.CompareTag("Bullet"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
