using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
    //core stats
    //time in s waited before next update
    private float updateInterval;
    //time in s since last update
    private float lastInterval;

    private bool alive;
    private int speed;
    private float hp;
    private int maxHp;
    private float petrify;
    private float petrifyTimeout;
    private float frozen;
    private float onFire;
    private float fireDmg;
    private float slow;

    public int MaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            maxHp = (value>0)? value : 1;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = (value>=0)? value : 0;
        }
    }

    public int Hp
    {
        get
        {
            return (int)hp;
        }

        set
        {
            if (value < 0) hp = 0;
            else if (value > MaxHp) hp = maxHp;
            else hp = value;
        }
    }

    public float Petrify
    {
        get
        {
            return petrify;
        }
        set
        {
            petrify = (value>=0)? value : 0;
        }
    }

    public float Frozen
    {
        get
        {
            return frozen;
        }
        set
        {
            frozen = (value >= 0) ? value : 0;
        }
    }

    public float Slow
    {
        get
        {
            return slow;
        }
        set
        {
            slow = (value >= 0) ? value : 0;
        }
    }


    // Use this for initialization
    void Start()
    {
        alive = true;
        Speed = 10;
        maxHp = 100;
        hp = maxHp;
        petrify = 0;
        frozen = 0;
        onFire = 0;

        updateInterval = 0.1f;
        lastInterval = 0;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        lastInterval += dt;
        if (lastInterval > updateInterval)
        {
            lastInterval -= updateInterval;

            if (petrify>0)
            {
                petrifyTimeout += dt;
                if (petrifyTimeout > 8)
                {
                    petrify = 0;
                    petrifyTimeout = 0;
                }
            }
            if (onFire > 0)
            {
                onFire -= dt;
                Damage(fireDmg);
                
            }
            if (frozen > 0)
            {
                petrify = 0;
                speed = 0;
                frozen -= dt;
                if (frozen < 0) speed = 10;
            }
            if (slow > 0)
            {
                if (speed > 5) speed = 5;
                slow -= dt;
                if (slow < 0) speed = 10;
            }
        }
    }

    public void Damage(float damage)
    {
        int tmp = (int)hp;
        hp -= damage;
        if (hp < 0) hp = 0;
        else if (hp > maxHp) hp = maxHp;
        if (tmp!=(int)hp) Debug.Log("HP: " + Hp + "/" + MaxHp);
    }

    public void Burn(float damage, float duration)
    {
        onFire = duration;
        fireDmg = damage;
    }
}