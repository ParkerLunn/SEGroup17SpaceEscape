using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    public float health;
    public float maxHealth = 100f;
    public float moveSpeed;

    public GameObject entity;

    public SpriteRenderer weapon;
    public Inventory inventory;

    private SpriteRenderer spriteRenderer;
    private Animator animator;


    // Use this for initialization
    void Start () {
        health = maxHealth;
        //entity = GetComponent<GameObject>();
        inventory.ItemUsed += Inventory_ItemUsed;

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ModifyHealth(float modifier) {
        health = health + modifier;
        if(IsMaxHealthExceeded())
        {
            health = maxHealth;
        }
        else if(!isAlive())
        {
            DestroyObject(entity);
            Destroy(entity);
            DestroyImmediate(entity);
        }

    }


    public void ModifyMaxHealth(float modifier)
    {
        maxHealth += modifier;
    }

    private bool IsMaxHealthExceeded()
    {
        return health > maxHealth;
    }

    private bool isAlive()
    {
        return health > 0f;
    }

    public void Die () {
        Destroy(entity);
    }

    public void ModifySpeed(float modifier)
    {
        moveSpeed += modifier;
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        ItemBaseClass item = e.Item;
        weapon.sprite = item.Image;
    }
}
