using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : ItemBaseClass {

    public float damage;
    public float projectileSpeed;
    public float rateOfFire = 0;
    public LayerMask objectsToDamage;

    Transform firePoint;
    float timeToFire;

    ShootProjectile projectile;

    void Start()
    {
        GameObject weapon = GetComponent<GameObject>();
        GameObject child = Helper.FindComponentInChildWithTag(weapon, "FiringPoint");
        Transform firePoint = child.transform;
        projectile.SetDamage(damage);
        projectile.SetSpeed(projectileSpeed);
    }

    void Update()
    {
        if(rateOfFire == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                projectile.Shoot(firePoint);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time > rateOfFire)
            {
                timeToFire = Time.time + 1 / rateOfFire;
                projectile.Shoot(firePoint);
            }
        }
    }

}