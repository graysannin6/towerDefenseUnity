using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;
    public float range = 15f;
    
    
    
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    
    
    public float turnspeed = 15f;
    [Header("Use Bullets (default)")]
    public float fireRate = 1f;
   private float fireCountdowm = 0f;
  
    
    public GameObject firing;
    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
   
    
    
    public float slowAmount = .5f;

    public LineRenderer lineRenderer;
    
    
    public ParticleSystem impactEffect;
    

    public Transform firePoint;
   



    void Start()
    {
        
        InvokeRepeating("TargetUpdate", 0f, 0.5f); //Invoke the method and repeat after certain time

       
    }

    void TargetUpdate() // allow the turret to track the enemy
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float lessDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distaceToenemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distaceToenemy < lessDistance)
            {
                lessDistance = distaceToenemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && lessDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
    void Update()
    {
            if (target == null)
            {
                if (useLaser)
                {
                    if (lineRenderer.enabled)
                    {
                        lineRenderer.enabled = false;
                        impactEffect.Stop();
                        
                    }
                }

                return;
            }

            LockOnTarget();

            if (useLaser)
            {
                Laser();
            }
            else
            {
                if (fireCountdowm <= 0f)
                {
                    Shoot();
                    fireCountdowm = 1f / fireRate;
                }

                   fireCountdowm -= Time.deltaTime;
            }

    }
    void OnDrawGizmosSelected() // allow us to see the range 
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Laser() // the function that allow us to use the line renderer
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    void LockOnTarget() // allow us to rotate the part that we want (the head of the tower)
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    private void Shoot() // the function that allow us to fire the bullet prefab
    {
        GameObject bulletShootingParticle = (GameObject)Instantiate(firing, firePoint.position, firePoint.rotation);
    
        Bullet bullet = bulletShootingParticle.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
        
    }


}