using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;

    [Header("Attribute")]

    
    private float range;
    private float fireRate;
    private float fireCoolDown;
    private int cost;
    [Header("UnitySetupFieldS")]

    public float turnpeed;
    public Transform partToRotate;

    public GameObject bulletPrefab;
    public Transform firePoint;

    public TurretBlueprint turretData;
    
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("updateTarget", 0f, 0.5f);

        
        range = turretData.range;
        fireRate = turretData.fireRate;
        fireCoolDown = turretData.fireCooldown;
        cost = turretData.cost;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation, Time.deltaTime * turnpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        if (fireCoolDown <= 0f)
        {
            Shoot();
            fireCoolDown = 1f / fireRate;
        }

        fireCoolDown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}