using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreate : MonoBehaviour {

    //private Collider2D cld2D;

    private TowerSpawner spawner;

    void Start () {
        //cld2D = gameObject.GetComponent<Collider2D>();
        spawner = GetComponentInParent<TowerSpawner>();
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        transform.parent.GetComponent<TowerSpawner>().collisionDetected(this);
        if (collision.gameObject.tag == "Player")
        {
            //cld2D.enabled = false;
            Debug.Log("collision on child");
            spawner.spawn(transform);
            Destroy(this.gameObject);
        }
    }
}
