using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //Goes for the Player and Base

    public float speed;

    //private Vector2 direction;
    //private Rigidbody2D rb2d;

    //private Transform player;
    private Vector2 target;

	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        //target = new Vector2(player.position.x, player.position.y);

        //rb2d = GetComponent<Rigidbody2D>();

        //rb2d.velocity = new Vector2(direction.x, direction.y);

        transform.right = new Vector3(target.x, target.y, 0) - transform.position;
    }

    public void SetTarget(Vector2 newTarget)
    {
        target = newTarget;
        //Debug.Log("new target set");
    }	

	void Update () {
        //to follow the player isntead of target do player.position
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        transform.position += transform.right * speed * Time.deltaTime;

        //if x and y coordinates are equal to the target's coordinates
        //if ((transform.position.x == target.x) && (transform.position.y == target.y))
        //{
        //    DestroyProjectile();
        //    Debug.Log("cheguei ao target");
        //}

        //if (transform.position.Equals(target))
        //{
        //    DestroyProjectile();
        //    Debug.Log("cheguei ao target");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Base") || collision.CompareTag("Bullet"))
        {
            DestroyProjectile();
        } 
        //else if (collision == null && (Time.time == 5f))
        //{
        //    Destroy(gameObject, 2f);
        //}
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
