using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIFollow : MonoBehaviour {

    private Vector3 Player;
    private Vector2 PlayerDirection;

    private Vector3 Base;
    private Vector2 BaseDirection;

    private float xDif, yDif;
    private float xDifB, yDifB;

    public float speed;
    private Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        Player = GameObject.Find("Player").transform.position;

        xDif = Player.x - transform.position.x;
        yDif = Player.y - transform.position.y;

        PlayerDirection = new Vector2(xDif, yDif);

        Base = GameObject.Find("Base").transform.position;

        xDifB = Base.x - transform.position.x;
        yDifB = Base.y - transform.position.y;
        BaseDirection = new Vector2(xDifB, yDifB);

        //if (Physics2D.Raycast(transform.position, PlayerDirection, 1)){
        //    rb2d.AddForce(PlayerDirection.normalized * speed);
        //} else{
        //    PlayerDirection = Vector2.zero;
        //}

        //if (PlayerDirection.sqrMagnitude < 3 * 3)
        //{
        //    rb2d.AddForce(PlayerDirection.normalized * speed);
        //}
        //else if (BaseDirection.sqrMagnitude < 10 * 10)
        //{
        //    //rb2d.AddForce(BaseDirection.normalized * speed);
        //    rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, Base, speed * Time.deltaTime /* 1 */);
        //}

        Debug.DrawLine(this.transform.position, Base);
        Debug.Log("mag:" + BaseDirection.magnitude);
        Debug.Log("sqr: " + BaseDirection.sqrMagnitude);
        //use this one 
        if (BaseDirection.sqrMagnitude < 50)
        {
            rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, Base, speed * Time.deltaTime /* 1 */);
        } else if (PlayerDirection.sqrMagnitude < 25)
        {
            rb2d.AddForce(PlayerDirection.normalized * speed);
        }else if (BaseDirection.sqrMagnitude < 100 * 100)
        {
            //rb2d.AddForce(BaseDirection.normalized * speed);
            rb2d.transform.position = Vector2.MoveTowards(rb2d.transform.position, Base, speed * Time.deltaTime /* 1 */);
        }
    }
}
