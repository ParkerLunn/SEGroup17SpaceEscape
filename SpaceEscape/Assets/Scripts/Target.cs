using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {
    public Text output;
    public AudioSource audiosrc;
    public AudioClip winmus;
    float interval, r, g, b;
    bool rs, gs, bs;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        interval += Time.deltaTime;
        if (interval >= 0 && interval < 0.1f && rs)
        {
            r = Random.value;
            rs = false;
        }
        if (interval >= 0.1f && interval < 0.2f && gs)
        {
            g = Random.value;
            gs = false;
        }
        if (interval >= 0.2f && interval < 0.3f && bs)
        {
            b = Random.value;
            gs = false;
        }
        if (interval >= 0.3f)
        {
            rs = true;
            gs = true;
            bs = true;
            output.color = new Color(r, g, b);
            interval = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            output.text = "WIN!";
            audiosrc.Stop();
            audiosrc.clip = winmus;
            audiosrc.Play();
        }

    }
}
