using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIShooterToPlayer : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public float priorityBaseDistance;


    void Start () {
        timeBtwShots = startTimeBtwShots;
    }
	
	void Update () {
		if (GameManager.instance.player != null) {
			Vector2 currentEnemy;
			float baseTDistance = Vector2.Distance(transform.position, GameManager.instance.baseObject.transform.position);
			if (baseTDistance <= priorityBaseDistance) {
				if (baseTDistance > stoppingDistance)
					transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.baseObject.transform.position, speed * Time.deltaTime);
				else if (baseTDistance < retreatDistance)
					transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.baseObject.transform.position, -speed * Time.deltaTime);

				transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.baseObject.transform.position, speed * Time.deltaTime);
				currentEnemy = new Vector2(GameManager.instance.baseObject.transform.position.x, GameManager.instance.baseObject.transform.position.y);
			} else {
				float playerDistance = Vector2.Distance(transform.position, GameManager.instance.player.transform.position);

				if (playerDistance > stoppingDistance)
					transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, speed * Time.deltaTime);
				else if (playerDistance < retreatDistance)
					transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.player.transform.position, -speed * Time.deltaTime);

				currentEnemy = new Vector2(GameManager.instance.player.transform.position.x, GameManager.instance.player.transform.position.y);
			}

			//Enemy Shots time between them
			if (Vector3.Distance(GameManager.instance.player.transform.position, transform.position) <= 15 && timeBtwShots <= 0) {
				EnemyBullet bullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<EnemyBullet>();
				bullet.SetTarget(new Vector2(currentEnemy.x, currentEnemy.y));

				timeBtwShots = startTimeBtwShots;
			} else {
				timeBtwShots -= Time.deltaTime;
			}
		}
    }
}
