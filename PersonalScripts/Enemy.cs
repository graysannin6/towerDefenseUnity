using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointindex = 0;
    //public float startHealth = 100;
    public  float health = 100f;
    public float startSpeed = 10f;
    public int worth = 50;
    private bool isDead = false;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = WavePoints.points[0];
        speed = startSpeed;
        //health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime,Space.World);

        if(Vector3.Distance(transform.position,target.position) <= 0.2f)
        {
            GetNextWavePoint();
        }
        transform.LookAt(target);
        speed = startSpeed;
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
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
    private void GetNextWavePoint()
    {
        if(wavepointindex >= WavePoints.points.Length -1)
        {
            EndPathing();
            return;
        }
        wavepointindex++;
        target = WavePoints.points[wavepointindex];
    }

    void Die()
    {
        isDead = true;

        PlayerManager.Gold += worth;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Spawner.AlienAlive--;

        Destroy(gameObject);
    }
    void EndPathing()
    {
        PlayerManager.Lives--;
        Spawner.AlienAlive--;
        Destroy(gameObject);
    }
}
