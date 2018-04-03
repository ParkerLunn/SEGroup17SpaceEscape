using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler {
	public Inventory inventory;

	public void OnDrop(PointerEventData eventData){
		RectTransform invPanel = transform as RectTransform;
		if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition)){
			Debug.Log("DROP ITEM");

			ItemBaseClass item = eventData.pointerDrag.gameObject.GetComponent<ItemDrag>().Item;
			Debug.Log (item);
			if(item != null){
				Debug.Log("ITEM NOT NULL");

				
				inventory.RemoveItem(item);
				item.OnDrop();
			}
		}
	}


}
