using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour {

    public float damage = 100;
    public float projectileSpeed;
    public float rateOfFire = 0;
    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 5;
    public LayerMask objectsToDamage;

    public Transform BulletTrailPrefab;
    
    private Transform firePoint;
    private float timeToFire = 0;
    public bool weaponEquipped;
    private GameObject player;

    ShootProjectile projectile;

    void Awake()
    {
        weaponEquipped = false;
        firePoint = transform.Find("weaponFP");
        //GameObject weapon = GetComponent<GameObject>();
        //GameObject child = Helper.FindComponentInChildWithTag(weapon, "FiringPoint");
        //Transform firePoint = child.transform;
        //projectile.SetDamage(damage);
        //projectile.SetSpeed(projectileSpeed);
    }

    void Update()
    {
        
        //Shoot();

        if (rateOfFire == 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //projectile.Shoot(firePoint);
                if(weaponEquipped)
                    Shoot();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time > rateOfFire)
            {
                timeToFire = Time.time + 1 / rateOfFire;
                if (weaponEquipped)
                    Shoot();
                //projectile.Shoot(firePoint);
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, objectsToDamage);
        if(Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1/effectSpawnRate;
        }
            
        //Debug.DrawLine(firePointPosition, 100*(mousePosition-firePointPosition));
        //Debug.Log("test");
        if(hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point,Color.red);
        }
        if (hit.collider.name.Contains("Enemy"))
        {
            hit.collider.GetComponent<Entity>().ModifyHealth(-damage);
        }
    }

    void Effect()
    {
        Vector3 mousePositionVector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        mousePositionVector3 = Camera.main.ScreenToWorldPoint(mousePositionVector3);
        Vector3 targetdir = mousePositionVector3 - transform.position;
        Instantiate(BulletTrailPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward, targetdir)*Quaternion.Euler(0,0,90));
    }

}
