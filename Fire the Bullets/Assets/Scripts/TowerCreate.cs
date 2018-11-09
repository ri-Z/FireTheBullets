using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCreate : MonoBehaviour {

    private SpriteRenderer sprite;
    private Collider2D cld2D;

    private Spawner spawner;

    void Start () {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        cld2D = gameObject.GetComponent<Collider2D>();
        spawner = GetComponentInParent<Spawner>();
	}
	
	void Update () {
		
	}

    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") == true)
    //    {
    //        sprite.enabled = true;
    //        Debug.Log("collision");
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        transform.parent.GetComponent<Spawner>().collisionDetected(this);
        if (collision.gameObject.tag == "Player")
        {
            cld2D.enabled = false;
            Debug.Log("collision on child");
            spawner.spawn();
        }
    }
}
