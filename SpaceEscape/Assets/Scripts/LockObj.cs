using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockObj : MonoBehaviour
{
    MonoBehaviour key;
    public bool locked;
    Animator animator;
    // Use this for initialization
    void Start()
    {
        key = GetComponent<MonoBehaviour>();
        locked = true;
        animator = GetComponent<Animator>();
        animator.SetBool("locked", locked);
    }

    public void Unlock()
    {
        //key.SendMessage("Use");
        locked = false;
        GetComponent<Collider2D>().enabled = locked; 
        animator.SetBool("locked", locked);

    }
    public void Lock()
    {
        //key.SendMessage("Use");
        locked = true;
        GetComponent<Collider2D>().enabled = locked;
        animator.SetBool("locked", locked);
    }
    public void Toggle()
    {
        if (locked) Unlock();
        else Lock();
    }
    void Use()
    {

    }

}

