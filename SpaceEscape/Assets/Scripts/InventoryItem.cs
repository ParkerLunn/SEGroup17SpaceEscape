//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//
//	public interface IInventoryItem {
//		string Name{ get; } // name of the object
//		Sprite Image{get;} //way to set sprite image of the object 
//		void pickupItem(); 
//		void OnDrop ();
//		InventorySlot Slot { get; set; }
//
//	}
//	
//public class InventoryEventArgs: EventArgs{
//	public InventoryEventArgs(IInventoryItem item){
//		Item = item;
//	}
//	public IInventoryItem Item;
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class InventoryEventArgs: EventArgs{
	public InventoryEventArgs(ItemBaseClass item){
		Item = item;
	}
	public ItemBaseClass Item;
}

