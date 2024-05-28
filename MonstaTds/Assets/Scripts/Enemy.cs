using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed = 10f;

    private Transform target;
    private int wavePointIndex = 0;
    public float startHealth = 100;
    private float health;

    public int worth = 50;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    //public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        target = WaypointControl.points[0];
        speed = startSpeed;
        health = startHealth;
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position,target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if (wavePointIndex >= WaypointControl.points.Length - 1)
        {
            Destroy(gameObject);
        }
        wavePointIndex++;
        target = WaypointControl.points[wavePointIndex];
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        //healthBar.fillAmount = health / startHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
    {
        isDead = true;

        PlayerStats.Money += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        //WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}