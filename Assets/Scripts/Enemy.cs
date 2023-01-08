using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float maxHealth = 100f;
    private float health;

    private void OnEnable()
    {
        Bullet.OnEnemyHit += TakeDamage;
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void TakeDamage(float _damages)
    {
        health -= _damages;
    }

    private void OnDisable()
    {
        Bullet.OnEnemyHit -= TakeDamage;        
    }
}
