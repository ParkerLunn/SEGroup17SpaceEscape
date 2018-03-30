//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//
//public class Inventory : MonoBehaviour {
//
//
//
//	public event EventHandler<InventoryEventArgs> ItemAdded;
//	public event EventHandler<InventoryEventArgs> ItemRemoved;
//	public GameObject inventory; 
//	public bool isActive;
//
//	private const int SLOTS = 9;
//	private bool isInventoryOpen = false;
//	private IList<InventorySlot> mSlots = new List<InventorySlot> ();
////	private IList<InventorySlot> mItems = new List<IInventoryItem> ();
//
//	 
//	void Start(){
////		inventory.SetActive(true);
////		isActive = true;
//	}
//	void Update(){
////		if (Input.GetKeyDown ("i") && isInventoryOpen == false) {
////			Debug.Log ("inventory open");
////			isInventoryOpen = true;
////
////		} else if (Input.GetKeyDown ("i") && isInventoryOpen == true) {
////			Debug.Log ("inventory close");
////			isInventoryOpen = false;
////		}
//	}
//
//	private InventorySlot FindStackableItem(IInventoryItem item){
//		foreach (InventorySlot slot in mSlots) {
//			if (slot.IsStackable (item))
//				return slot;
//		}
//		return null;
//	}
//
//	private InventorySlot FindNextEmptySlot(){
//		foreach (InventorySlot slot in mSlots) {
//			if (slot.IsEmpty)
//				return slot; 
//		}
//		return null;
//	}
//
//	public void AddItem(IInventoryItem item){
//		InventorySlot newSlot = FindStackableItem (item);
//		if (newSlot == null) {
//			newSlot = FindNextEmptySlot();
//		}
//		if (newSlot != null) {
//			newSlot.AddItem (item);
//	
//			if (ItemAdded != null) {
//				ItemAdded (this, new InventoryEventArgs (item));
//			}
//		}
////		if (mItems.Count < SLOTS)
////		{
////			Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D> ();
////			if (collider.enabled) {
////				collider.enabled = false;
////				mItems.Add (item);
////				item.pickupItem ();
////
////				if (item != null) {
////					ItemAdded (this, new InventoryEventArgs (item));
////				}
////			}
////		}
//	}
//
//	public void RemoveItem(IInventoryItem item){
//		foreach (InventorySlot slot in mSlots) {
//			if (slot.Remove (item)) {
//				if (ItemRemoved != null) {
//					ItemRemoved (this, new InventoryEventArgs (item));
//				}
//				break;
//			}
//		}
//
//	}
//		
//
//}










using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour {



	public event EventHandler<InventoryEventArgs> ItemAdded;
	public event EventHandler<InventoryEventArgs> ItemRemoved;
	//public GameObject inventory; 
	public bool isActive;

	private const int SLOTS = 9;
	private bool isInventoryOpen = false;
	private IList<InventorySlot> mSlots = new List<InventorySlot> ();

	public Inventory(){
		for (int i = 0; i < SLOTS; i++) {
			mSlots.Add (new InventorySlot(i));
		}
	}


	void Start(){
		//		inventory.SetActive(true);
		//		isActive = true;
	}
	void Update(){
		//		if (Input.GetKeyDown ("i") && isInventoryOpen == false) {
		//			Debug.Log ("inventory open");
		//			isInventoryOpen = true;
		//
		//		} else if (Input.GetKeyDown ("i") && isInventoryOpen == true) {
		//			Debug.Log ("inventory close");
		//			isInventoryOpen = false;
		//		}
	}

	private InventorySlot FindStackableItem(ItemBaseClass item){
		foreach (InventorySlot slot in mSlots) {
			if (slot.IsStackable (item))
			//	Debug.Log ("HELP " + slot);
				return slot;
		}
		//Debug.Log ("HELP NULL");
		return null;
	}

	private InventorySlot FindNextEmptySlot(){
		foreach (InventorySlot slot in mSlots) {
			
			if (slot.IsEmpty) {
				//Debug.Log ("IM HERE: " + slot);
				return slot; 
			}
		}
		return null;
	}

	public void AddItem(ItemBaseClass item){
		//Debug.Log ("ADDDDDD");
		item.pickupItem ();
		InventorySlot newSlot = FindStackableItem (item);
		if (newSlot == null) {
			newSlot = FindNextEmptySlot();
			//Debug.Log ("AddItem----newSlot: NULL"+ newSlot);
		}
		if (newSlot != null) {
			newSlot.AddItem (item);
			//Debug.Log ("AddItem to slot");

			if (ItemAdded != null) {
				ItemAdded (this, new InventoryEventArgs (item));
			}
		}
		//		if (mItems.Count < SLOTS)
		//		{
		//			Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D> ();
		//			if (collider.enabled) {
		//				collider.enabled = false;
		//				mItems.Add (item);
		//				item.pickupItem ();
		//
		//				if (item != null) {
		//					ItemAdded (this, new InventoryEventArgs (item));
		//				}
		//			}
		//		}
	}

	public void RemoveItem(ItemBaseClass item){
		foreach (InventorySlot slot in mSlots) {
			if (slot.Remove (item)) {
				if (ItemRemoved != null) {
					ItemRemoved (this, new InventoryEventArgs (item));
				}
				break;
			}
		}

	}


}
