using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1Shooter : MonoBehaviour {

    public float speed;

    private Transform player;
    private Vector2 target;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
	}
	
	void Update () {
        //to follow the player isntead of target do player.position
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

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
