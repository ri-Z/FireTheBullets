using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimShoot : MonoBehaviour {

    //public Transform target;

    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public int maxAmmo = 3;
    private int currentAmmo;
    public float reoladTime = 2f;
    private bool isReloading = false;

    void Start () {
        timeBtwShots = startTimeBtwShots;

        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
    }

    void Update () {

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reloading());
            return;
        }

        //target.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //THESE TWO LINES ARE TO ROTATE THE WEAPON TOWARDS THE DIRECTION OF THE MOUSE
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = -direction; //negative direction because the sprite of the weapon is facing down

        //transform.LookAt(direction); THIS LINE IS NOT WORKING


        //Shooting
        Shooting();
    }

    void Shooting(){
        if (Input.GetMouseButtonDown(0) && timeBtwShots <= 0)
        {
            //Spawner spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
            //spawner.spawn();

            Debug.Log("Fire the Bullets");
            Instantiate(projectile, shotPoint.position, Quaternion.identity);
            currentAmmo--;
            timeBtwShots = startTimeBtwShots;
        }else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    IEnumerator Reloading(){

        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reoladTime);

        currentAmmo = maxAmmo;

        isReloading = false;
    }
}
