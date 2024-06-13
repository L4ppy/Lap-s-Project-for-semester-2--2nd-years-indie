using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;

    public bool useLaser;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    
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
        if (gameObject.GetComponent<LineRenderer>() != null)
            lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
                laser();
            }
        else
        {
            if (turretData.fireCoolDown <= 0f)
            {
                Shoot();
                turretData.fireCoolDown = 1f / turretData.fireRate;
            }
        }
            
        turretData.fireCoolDown -= Time.deltaTime;
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void laser()
    {
        
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1,target.position);
        target.GetComponent<Enemy>().TakeDamage(1f);
        target.GetComponent<Enemy>().Slow(0.5f);
        Vector3 dir = firePoint.position - target.position;


        impactEffect.transform.position = target.position + dir.normalized * .5f;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);


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

        if (nearestEnemy != null && shortestDistance <= turretData.range){
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
        Gizmos.DrawWireSphere(transform.position, turretData.range);
    }
}
