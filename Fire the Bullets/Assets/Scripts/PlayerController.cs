using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private PlayerController player; 

    [SerializeField]
    private float speed = 10f;

    private Rigidbody2D rb;
    private Animator anim;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    private void Awake(){
        Debug.Log("Awake");
    }

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        //verticalMove = Input.GetAxisRaw("Vertical") * speed;
    }

    void FixedUpdate(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        verticalMove = Input.GetAxisRaw("Vertical") * speed;

        Vector2 movement = new Vector2(horizontalMove, verticalMove);
        //Debug.Log("moving");

        if (movement != Vector2.zero){
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", movement.x);
            anim.SetFloat("input_y", movement.y);
        } else {
            anim.SetBool("isWalking", false);
        }

        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }
}
