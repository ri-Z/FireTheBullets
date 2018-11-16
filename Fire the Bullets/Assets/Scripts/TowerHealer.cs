using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealer : MonoBehaviour, ITowerProjectile{

    //public float timeBtwShots = 2f;

    private Transform target;
    public float healStrenght = 20f;
    public float speed = 70f;

	public void SetTarget(Transform target){
		this.target = target;
	}

    void Start()
    {
        //if (timeBtwShots <= 0)
        //{
        //    timeBtwShots -= Time.deltaTime;
        //}
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            hitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void hitTarget()
    {
        GameManager.instance.player.healHit(healStrenght);
        Destroy(gameObject);
    }
}
