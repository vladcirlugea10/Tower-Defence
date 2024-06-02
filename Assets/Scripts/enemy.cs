using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    
    public float startHealth = 100;
    private float health;
    public int worth = 50;

    public Image healthBar;

    private bool isDead = false;
    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health<=0 && !isDead)
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

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

}
