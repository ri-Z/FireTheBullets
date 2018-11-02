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
    private Transform player;
    private Transform baseT;

    //range to attack other stuff
    private Vector3 Player;
    //private Vector2 PlayerDirection;
    private Vector3 Base;
    //private Vector2 BaseDirection;
    //private float xDif, yDif;
    //private float xDifB, yDifB;
    //private Rigidbody2D rb2d;
    //public float stoppingDistanceBase;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        baseT = GameObject.FindGameObjectWithTag("Base").transform;

        timeBtwShots = startTimeBtwShots;

        Player = GameObject.Find("Player").transform.position;
        Base = GameObject.Find("Base").transform.position;
        //rb2d = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        //Enemy movement em relacao ao player
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        //else if (Vector2.Distance(transform.position, baseT.position) > stoppingDistanceBase)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}

        //Enemy Shots
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if istouching

        ////Ranges
        ////Player Range
        //xDif = Player.x - transform.position.x;
        //yDif = Player.y - transform.position.y;
        //PlayerDirection = new Vector2(xDif, yDif);

        ////Base Range
        //xDifB = Base.x - transform.position.x;
        //yDifB = Base.y - transform.position.y;
        //BaseDirection = new Vector2(xDifB, yDifB);

        ////Range Calculation
        //Debug.DrawLine(this.transform.position, BaseDirection);
        //Debug.Log("mag:" + BaseDirection.magnitude);
        //Debug.Log("sqr: " + BaseDirection.sqrMagnitude);
        //if (BaseDirection.sqrMagnitude < 50)
        //{
        //    rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, Base, speed * Time.deltaTime /* 1 */);
        //}
        //else if (PlayerDirection.sqrMagnitude < 25)
        //{
        //    //rb2d.AddForce(PlayerDirection.normalized * speed);
        //    rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, Player, speed * Time.deltaTime /* 1 */);
        //}
        //else if (BaseDirection.sqrMagnitude < 100 * 100)
        //{
        //    rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, Base, speed * Time.deltaTime /* 1 */);
        //}
    }
}
