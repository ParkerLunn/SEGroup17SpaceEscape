using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
    //Public stats will be made read-only.
    //methods will be provided for modification of values.

    //time in s waited before next update
    float updateInterval;
    //time since last applied update
    float lastInterval;

    List<Effect> effects;
    Entity playerEntity = GameObject.Find("Player").GetComponent<Entity>();
    bool alive;
    float hp;
    float maxHp;

    List<float> speed;
    float speedCache;
    float speedMax;
    float speedMin;
    float petrify;
    float frozen;

    public float MaxHp
    {
        get
        {
            return playerEntity.maxHealth;
        }

        set
        {
            maxHp = (value>0)? value : 1;
        }
    }

    public float Speed
    {
        get
        {
            return speedCache;
        }
    }

    public float Hp
    {
        get
        {
            return playerEntity.health;
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



    /* methods
     *      DAMAGE: all methods that use damage as a parameter take positive
     * or negative values. Negative values heal, positives hurt.
     * Health will stay in the range of 0 to max HP.
     *      DURATION: all methods that use duration take a float counted in s.
     * negative durations are applied indefinitely.
     * Durations will timeout the effect after duration seconds.
     *      SPEED: all methods that use speedChange multiply the current speed by
     * the modifier
     *      SOURCE AND SOURCE NAME: these parameters reference the gameObject that
     * created the event. Source for the gameObject, Source name for its name.
     */


    //attempts to reduce HP by damage points.
    public void Damage(GameObject source, float damage)
    {
        effects.Add(new Effect(source, "hp", damage * -1, 0, false, false));
    }
    //reduce HP by damagepersecond DPS over duration seconds.
    public void DamageOverTime(GameObject source, float damagePerSecond, float duration)
    {
        bool isCont = (duration <= 0) ? true : false;
        effects.Add(new Effect(source, "hpot", damagePerSecond * -1, duration, true, isCont));
    }
    //multiplies speed by speedChange. Default speed modifier is 1. 
    public void SpeedChange(GameObject source, float speedChange, float duration)
    {
        bool isCont = (duration <= 0) ? true : false;
        effects.Add(new Effect(source, "speed", speedChange, duration, true, isCont));
    }
    //sets all effects from a game object as no longer continuous and sets duration.
    //returns the integer count of successful changes.
    public int DisableContinuousEffect(GameObject source, float duration)
    {
        int result = 0;
        foreach (Effect e in effects)
        {
            if (e.source.Equals(source))
            {
                result++;
                e.duration = duration;
                e.continuous = false;
            }
        }
        //Debug.Log("ATTN:\t removing continuous effect!");
        return result;
    }
    public int DisableContinuousEffect(string sourceName, float duration)
    {
        int result = 0;
        foreach (Effect e in effects)
        {
            if (e.source.name.Equals(sourceName))
            {
                result++;
                e.duration = duration;
                e.continuous = false;
            }
        }
        //Debug.Log("ATTN:\t removing continuous effect!");
        return result;
    }
    //[DEBUG] Returns the first Effect set by a game object. Returns null on failure. 
    public Effect GetEffectByGameObject(GameObject source)
    {
        Effect result = null;
        foreach (Effect e in effects)
        {
            if (e.source.Equals(source))
            {
                result = e;
                return result;
            }
        }
        return result;
    }
    public Effect GetEffectByGameObject(string sourceName)
    {
        Effect result = null;
        foreach (Effect e in effects)
        {
            if (e.source.name.Equals(sourceName))
            {
                return result;
            }
        }
        return result;
    }

    //updates the value in the speed cache. returns true if accurate to speed.
    bool UpdateSpeed()
    {
        bool ret = true;
        float fl = 1;
        if (speed.Count > 0)
        {
            foreach (float s in speed)
            {
                fl = fl * s;
            }
        }
        if (fl > speedMax)
        {
            Debug.Log("ATTN:\tspeed is too high!");
            fl = speedMax;
            ret = false;
        }
        if (fl < speedMin)
        {
            Debug.Log("ATTN:\tspeed is too low!");
            fl = speedMin;
            ret = false;
        }
        if (frozen > 0) fl = 0;
        speedCache = fl;
        GetComponent<Rigidbody2D>().drag = 10 / speedCache;
        return ret;
    }

    void Start()
    {
        effects = new List<Effect>();
        speed = new List<float>();

        speedMax = 4;
        speedMin = 0.1f;
        speedCache = 1;

        maxHp = 100;
        hp = maxHp;
        alive = true;

        petrify = 0;
        frozen = 0;

        updateInterval = 0.1f;
        lastInterval = 0;
    }

    void Update()
    {
        lastInterval += Time.deltaTime;
        if (lastInterval > updateInterval)
        {
            for (int i = 0; i < effects.Count; i++)
            {
                switch (effects[i].name)
                {
                    case "hp":
                    case "hpot":
                        {
                            if (alive)
                            {
                                //add amount specified in magnitude to hp.
                                hp += (effects[i].active) ? effects[i].magnitude * lastInterval :
                                    effects[i].magnitude;
                                //keep hp between 0 and Max HP 
                                if (hp < 0) hp = 0;
                                else if (hp > maxHp) hp = maxHp;
                                //if Active, make it an effect over time.
                                //remove when finished.
                                if (effects[i].active)
                                {

                                    //if continuous, do not reduce alarm or remove.
                                    if (!effects[i].continuous)
                                    {
                                        effects[i].duration -= lastInterval;
                                        if (effects[i].duration < 0) effects.RemoveAt(i);
                                    }
                                }
                                //otherwise remove the effect after applying.
                                else effects.RemoveAt(i);
                            }

                            if (alive && Hp == 0)
                            {
                                alive = false;
                                hp = 0;
                            }
                            break;
                        }
                    case "speed":
                        {
                            //multiply speed by amount specified in magnitude if active,
                            //otherwise leave it.
                            if (effects[i].active)
                            {
                                speed.Add(effects[i].magnitude);
                                effects[i].active = false;
                            }
                            //if not a continuous effect, decrease timer and remove when done;
                            if (!effects[i].continuous)
                            {
                                effects[i].duration -= lastInterval;
                                if (effects[i].duration <= 0)
                                {
                                    speed.Remove(effects[i].magnitude);
                                    effects.RemoveAt(i);
                                    
                                }
                            }
                            UpdateSpeed();
                            break;
                        }
                    default:
                        {
                            if (!effects[i].printed)
                            {
                                Debug.Log("ERROR: Unknown Effect in update list!");
                                effects[i].Print();
                            }
                            break;
                        }
                }



            }
            lastInterval = 0;
        }
    }

}

public class Effect
{
    public string name;
    public GameObject source;
    public float magnitude;
    public float duration;
    public bool active;
    public bool continuous;
    public bool printed;

    public Effect()
    {
        name = null;
        source = null;
        magnitude = 0;
        duration = 0;
        active = false;
        continuous = false;
        printed = false;
    }
    public Effect(GameObject _source, string _name, float _magnitude, float _duration, bool _active, bool _continuous)
    {
        name = _name;
        magnitude = _magnitude;
        duration = _duration;
        source = _source;
        active = _active;
        continuous = _continuous;
        //if (continuous) Debug.Log("ATTN:\t adding continuous effect!");
    }
    public Effect(bool print, GameObject _source, string _name, float _magnitude, float _duration, bool _active, bool _continuous)
    {
        name = _name;
        magnitude = _magnitude;
        duration = _duration;
        source = _source;
        active = _active;
        continuous = _continuous;
        if (print) Print();
        //if (continuous) Debug.Log("ATTN:\t adding continuous effect!");
    }
    public void Print()
    {
        if (!printed)
        {
            Debug.Log("PRINTOUT FOR EFFECT \"" + name + "\"" +
            "\nSOURCE:\t" + source.name +
            "\nMAGNITUDE:\t" + magnitude +
            "\nDURATION:\t" + duration +
            "\nACTIVE:\t\t" + active +
            "\nCONTINUOUS:\t" + continuous);
            printed = true;
        }
    }
}