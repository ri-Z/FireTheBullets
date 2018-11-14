using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //Goes for the Player and Base

    public float damage;
    public float speed;
    private Vector2 target;

	void Start () {
        //target = new Vector2(player.position.x, player.position.y);

        transform.right = new Vector3(target.x, target.y, 0) - transform.position;
    }

    public void SetTarget(Vector2 newTarget)
    {
        target = newTarget;
    }	

	void Update () {
        //to follow the player isntead of target do player.position
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.position += transform.right * speed * Time.deltaTime;

        //if x and y coordinates are equal to the target's coordinates
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
