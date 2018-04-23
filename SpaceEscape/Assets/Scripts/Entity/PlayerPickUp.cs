using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour {

	public Inventory inventory;

	private void OnTriggerEnter2D(Collider2D other){ 
		InteractableItemBaseClass item = other.GetComponent<InteractableItemBaseClass> (); //sets var item into object player ran into
		if (item != null) { 
			inventory.AddItem (item as ItemBaseClass); // adds item into inventory 
			Debug.Log ("Adding: " + item);
		}
	}
}
