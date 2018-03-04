using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    List<Item> items;
	// Use this for initialization
	void Start () {
        items = new List<Item>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Item Use() {
        Item result = null;
        return result;
    }
    public void get(Item item)
    {
        items.Add(item);
    }
    
}

public class Item
{
    string name;
    int count;
    public Item() { }
    public Item(string _name, int _count)
    {
        name = _name;
        count = _count;
    }
}
