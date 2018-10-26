using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimShoot : MonoBehaviour {

    //public Transform target;

    public GameObject projectile;
    public Transform shotPoint;

    void Start () {
        
    }
    
    void Update () {
        //target.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));


        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //THESE TWO LINES ARE TO ROTATE THE WEAPON TOWARDS THE DIRECTION OF THE MOUSE
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = -direction; //negative direction because the sprite of the weapon is facing down

        //transform.LookAt(direction); THIS LINE IS NOT WORKING


        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fire the Bullets");
            Instantiate(projectile, shotPoint.position, Quaternion.identity);
        }
    }
}
