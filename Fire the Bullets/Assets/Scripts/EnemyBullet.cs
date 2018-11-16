using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    //Goes for the Player and Base

    public float damage;
    public float speed;

    private Transform player;
    private Vector2 target;

	void Start () {
        //target = new Vector2(player.position.x, player.position.y);

        //transform.right = new Vector3(target.x, target.y, 0) - transform.position;
    }

    public void SetTarget(Vector2 newTarget)
    {
        target = newTarget;
		transform.right = new Vector3(target.x, target.y, 0) - transform.position; //lookAt() but in 2D
    }	

	void Update () {
        //to follow the player isntead of target do player.position
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //transform.position += transform.right * speed * Time.deltaTime;

        //if x and y coordinates are equal to the target's coordinates
        //if (transform.position.Equals(target))
        //{
        //    DestroyProjectile();
        //    Debug.Log("cheguei ao target");
        //}

		if (target != null) {
			//to follow the player isntead of target do player.position
			transform.position += transform.right * speed * Time.deltaTime;
		}
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.CompareTag("Player")) {
			GameManager.instance.player.Hit(this);
			DestroyProjectile();
		} else if (collision.CompareTag("Base")) {
			GameManager.instance.baseObject.Hit(this);
			DestroyProjectile();
		} else if (collision.CompareTag("Bullet")) {
			DestroyProjectile();
		}
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
