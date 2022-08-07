using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlayerId = 0;

    public float MaxHealth = 100f;
    public float CurrentHealth;

    public float maxSpeed = 5f;
    public float acceleration = 15f;
    
    public float BulletDamage = 12f;
    public int Piercing = 2;
    public float BulletSpread = 30;
    public int Projectiles = 2;
    public float BulletSpeed = 4;
    
    public float KnockBackTime = 0.5f;

    public float EnemySpawnWaitTime = 2f;


    void Start()
    {
        CurrentHealth = MaxHealth;
    }



    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
    }

}
