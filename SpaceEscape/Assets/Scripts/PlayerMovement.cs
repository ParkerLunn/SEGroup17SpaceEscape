using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody2D rb2d;
    Animator animator;
    Status status;

    float speed;
    Vector2 movement;
    int direction;

    // Use this for initialization
    protected virtual void Start()
    {
        //Get a component reference to this object's Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();
        //Get a component reference to this object's MobStatus
        status = GetComponent("Status") as Status;

        //set the player's inherent speed
        speed = 2500f;
        direction = 3;
        //get the animation element
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    // Applies force to RigidBody2D based on current inputs, inherent speed,
    // and speedc modifier.
    void Update()
    {
        float effectiveSpeed = Time.deltaTime * speed;// * status.Speed;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            if (movement.x > 0) direction = 0;
            else if (movement.x < 0) direction = 2;
        }
        else
        {
            if (movement.y > 0) direction = 1;
            else if (movement.y < 0) direction = 3;
        }
        animator.SetInteger("direction", direction);

        animator.SetFloat("moving", Mathf.Sqrt(rb2d.velocity.x *
            rb2d.velocity.x + rb2d.velocity.y * rb2d.velocity.y)
            *0.15f);
        rb2d.AddForce(movement * effectiveSpeed);

        //transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
