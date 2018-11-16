using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIShooterToBase : MonoBehaviour{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    private Vector2 currentEnemy;

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
		if (GameManager.instance.baseObject != null) {
			//Enemy movement em relacao a base
			float baseTDistance = Vector2.Distance(transform.position, GameManager.instance.baseObject.transform.position);

			if (baseTDistance > stoppingDistance)
				transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.baseObject.transform.position, speed * Time.deltaTime);
			else if (baseTDistance < retreatDistance)
				transform.position = Vector2.MoveTowards(transform.position, GameManager.instance.baseObject.transform.position, -speed * Time.deltaTime);

			//transform.position = Vector2.MoveTowards(transform.position, Base.position, speed * Time.deltaTime);
			currentEnemy = new Vector2(GameManager.instance.baseObject.transform.position.x, GameManager.instance.baseObject.transform.position.y);

			//Enemy Shots
			if ( Vector3.Distance(GameManager.instance.baseObject.transform.position, transform.position) <= 15 && timeBtwShots <= 0) {
				EnemyBullet bullet = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<EnemyBullet>();
				bullet.SetTarget(currentEnemy);

				timeBtwShots = startTimeBtwShots;
			} else {
				timeBtwShots -= Time.deltaTime;
			}
		}
    }
}
