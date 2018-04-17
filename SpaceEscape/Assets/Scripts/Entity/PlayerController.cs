using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidbody;
    Entity player;


    private bool facingRight;
    //private SpriteRenderer spriteRenderer;
    //private Animator animator;

    // Use this for initialization
    void Start () {
        facingRight = true;
        rigidbody = GetComponent<Rigidbody2D>();
        player = GetComponent<Entity>();

        //animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidbody.AddForce(movement * player.moveSpeed);
        //animator.SetFloat("moveSpeed", movement.magnitude);
        Flip(moveHorizontal);
	}

    private void Flip(float horizontalMovement)
    {
        if(horizontalMovement > 0 && !facingRight || horizontalMovement < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
