using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class PlayerSounds : MonoBehaviour {
    //public PlayerController controller;
    public Inventory inventory;
    bool stepFlip;
    public float interval;
    public float dinterval;
    public AudioSource audioSource;
    public AudioClip s_step;
    public AudioClip s_getItem;
    public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        //controller = GetComponent("PlayerController") as PlayerController;
        //inventory = GetComponent("Inventory") as Inventory;
        s_step = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Sounds/step.wav", typeof(AudioClip));
        s_getItem = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Sounds/Ammo Get.wav", typeof(AudioClip));
        audioSource = GetComponent<AudioSource>();
        dinterval = 0;
        interval = 0.3f;
        rb2d = GetComponent<Rigidbody2D>();

        inventory.ItemAdded += Inventory_ItemAdded;

    }

    private void Inventory_ItemAdded(object sender, InventoryEventArgs e)
    {
        audioSource.PlayOneShot(s_getItem, 0.02f);
        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
        //This controlls player footfalls.
		if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!= 0)
        {
            if (dinterval <= 0)
            {
                dinterval += interval;
                float f = Mathf.Abs(rb2d.velocity.x) + 
                    Mathf.Abs(rb2d.velocity.y);
                if (f > 0.1)
                    audioSource.PlayOneShot(s_step, 0.5f);
            }
            else
                dinterval -= Time.deltaTime;
        }
        //This controlls item pickups.
        
	}
}
