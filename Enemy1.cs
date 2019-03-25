using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Enemy1 : MonoBehaviour
{

    public float startHealth = 100f;
    private float health;
    public int worth = 50;

    public GameObject deathEffect;

    public float startSpeed = 5f;
    [HideInInspector]
    public float speed; // Enemy hareket hızı

    [Header("Unity Stuff")]
    public Image healthBar;
    private bool isDead = false;

    void Start ()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;


        if (health <= 0 && !isDead)
        {

            Die();
        }
    }

    public void Slow(float yavaslatma)
    {
        speed = startSpeed * (1f - yavaslatma);  // İSTERSEN YAVAŞLATMA İŞLEMİNİ BURADAN DEĞİŞTİREBİLİRSİN.
    }

    void Die()
    {
        isDead = true;


        PlayerStats.Money += worth;
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        WaveSpawner.EnemiesAlive--;

        FindObjectOfType<AudioManager>().Play("PlayerDeath");

        Destroy(gameObject);
    }
 
}
