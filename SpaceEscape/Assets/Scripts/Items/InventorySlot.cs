using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot{
	private Stack<ItemBaseClass> mItemStack = new Stack<ItemBaseClass> ();
	private int mId = 0; 


	public InventorySlot(int id){
	mId = id;
	}

	public int Id{
		get{ return mId; }
	}

	public void AddItem(ItemBaseClass item){
		item.Slot = this;
		mItemStack.Push (item);
		//Debug.Log ("AddItem");
	}

	public ItemBaseClass FirstItem{
		get{ 
			if (IsEmpty)
				return null;
			return mItemStack.Peek ();
		}  
	}

	public bool IsStackable(ItemBaseClass item){
		if (IsEmpty)
			return false; 

		ItemBaseClass first = mItemStack.Peek ();
		Debug.Log ("FIRST" + first.Name);

		if (first.Name == item.Name)
			return true;
		return false;
	}

	public bool IsEmpty{
		get{ return Count == 0; }
	}

	public int Count{
		get{ return mItemStack.Count; }
	}
	public bool Remove(ItemBaseClass item){
		if (IsEmpty)
			return false;

		ItemBaseClass first = mItemStack.Peek ();
		if (first.Name == item.Name) {
			mItemStack.Pop ();
			return true;
		}
		return false; 
	}

}




