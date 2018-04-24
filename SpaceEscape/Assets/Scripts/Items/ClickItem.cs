using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickItem : MonoBehaviour {

	public Inventory inventory;

	public void onItemClick(){
		ItemDrag itemDrag = gameObject.transform.Find ("ItemImage").GetComponent<ItemDrag>();
        GameObject player = GameObject.Find("Player");
        if (player == null)
            Debug.Log("player null");
        ItemBaseClass item = itemDrag.Item;

		Debug.Log ("CLICK" + item);
        Debug.Log(item.Name + " equipped");
        if (item.name.Equals("Pistol"))
        {
            WeaponFire Wp = GameObject.Find("Player").GetComponentInChildren<WeaponFire>();
            if (Wp == null)
                Debug.Log("weapon null");
            else
                Debug.Log("pistol equipped");
            Wp.rateOfFire = 0;
            Wp.damage = 50;
            Wp.weaponEquipped = true;
        }
        if (item.name.Equals("MiniGun"))
        {
            WeaponFire Wp = GameObject.Find("Player").GetComponentInChildren<WeaponFire>();
            if (Wp == null)
                Debug.Log("weapon null");
            else
                Debug.Log("minigun equipped");
            Wp.rateOfFire = 20;
            Wp.damage = 5;
            Wp.weaponEquipped = true;
        }
        else
        {
            WeaponFire Wp = GameObject.Find("Player").GetComponentInChildren<WeaponFire>();
            if (Wp == null)
                Debug.Log("weapon null");
            Wp.weaponEquipped = false;
        }
        inventory.UseItem (item);
		//		item.OnUse();
	}
}
