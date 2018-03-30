using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Status status;
	public Inventory inventory; 

	private Rigidbody2D rb2D;
    private float speed;
    private Vector2 movement;

    // Use this for initialization
    protected virtual void Start()
    {
        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();
        //Get a component reference to this object's MobStatus
        status = GetComponent("Status") as Status;

        //set the player's inherent speed
        speed = 50.0f;
    }

	//function for when player runs into object
	private void OnTriggerEnter2D(Collider2D other){ 
		InteractableItemBaseClass item = other.GetComponent<InteractableItemBaseClass> (); //sets var item into object player ran into
		if (item != null) { 
			inventory.AddItem (item as ItemBaseClass); // adds item into inventory 
			Debug.Log ("Adding: " + item);
		}
	}


    // Update is called once per frame
    void Update()
    {
        
        float effectiveSpeed = Time.deltaTime * speed * status.Speed;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb2D.velocity = movement * effectiveSpeed;
    }

}
