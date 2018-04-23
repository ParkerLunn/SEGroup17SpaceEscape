//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//
//public class ItemBaseClass : MonoBehaviour, IInventoryItem {
//
//	public virtual string Name{
//		get{ 
//			return "_base item_";
//			}
//	}
//	public Sprite image; 
//	public Sprite Image{
//		get{ 
//			return image;
//		}
//	}
//
//	public virtual InventorySlot Slot {
//		get;
//		set;
//	}
//
//	public virtual void pickupItem(){
//		gameObject.SetActive(false);
//	}
//
//	public virtual void OnDrop(){
//		RaycastHit hit = new RaycastHit ();
//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//		if (Physics.Raycast(ray, out hit, 1000)){
//			gameObject.SetActive(true);
//			gameObject.transform.position = hit.point; 
//		}
//	}
//}
//





using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableItemBaseClass : MonoBehaviour{

	public string Name;
		
	public Sprite Image; 

}

public class ItemBaseClass:InteractableItemBaseClass{

	public InventorySlot Slot {
		get;
		set;
	}

	public virtual void pickupItem(){
//		Destroy(gameObject.GetComponents<RigidbodyConstraints2D>());
		gameObject.SetActive(false);
	}

	public virtual void OnDrop(){
		RaycastHit hit = new RaycastHit ();
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 1000)){
			gameObject.SetActive(true);
			gameObject.transform.position = hit.point; 
		}
	}

    public virtual void setActive()
    {
        //		Destroy(gameObject.GetComponents<RigidbodyConstraints2D>());
        gameObject.SetActive(true);
    }

}




