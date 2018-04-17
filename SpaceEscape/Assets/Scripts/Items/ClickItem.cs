using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItem : MonoBehaviour {

	public Inventory inventory;

	public void onItemClick(){
		ItemDrag itemDrag = gameObject.transform.Find ("ItemImage").GetComponent<ItemDrag>();

		ItemBaseClass item = itemDrag.Item;

		Debug.Log ("CLICK" + item);
		inventory.UseItem (item);
		//		item.OnUse();
	}
}
