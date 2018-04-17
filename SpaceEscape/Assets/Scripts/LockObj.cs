using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LockObj : MonoBehaviour
{
    MonoBehaviour key;
    public bool locked;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    Animator animator;
    AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        key = GetComponent<MonoBehaviour>();
        locked = true;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.SetBool("locked", locked);

        doorOpenSound = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Sounds/door open.wav", typeof(AudioClip));
        doorCloseSound = (AudioClip)AssetDatabase.LoadAssetAtPath("Assets/Sounds/door close.wav", typeof(AudioClip));
    }

    public void Unlock()
    {
        if (locked == true)
        {
            //key.SendMessage("Use");
            locked = false;
            GetComponent<Collider2D>().enabled = locked;
            animator.SetBool("locked", locked);
            audioSource.PlayOneShot(doorOpenSound, 0.25f);
        }

    }
    public void Lock()
    {
        if (locked == false)
        {
            //key.SendMessage("Use");
            locked = true;
            GetComponent<Collider2D>().enabled = locked;
            animator.SetBool("locked", locked);
            audioSource.PlayOneShot(doorCloseSound, 0.25f);
        }
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

