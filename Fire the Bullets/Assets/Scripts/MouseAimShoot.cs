using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimShoot : MonoBehaviour {

    //public Transform target;

    public GameObject projectile;

    void Start () {
		
	}
	
	void Update () {
        //target.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = -direction;
        //transform.LookAt(direction); NOT WORKING


        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fire the Bullets");
            Instantiate(projectile, direction, Quaternion.identity);
        }
    }
}
