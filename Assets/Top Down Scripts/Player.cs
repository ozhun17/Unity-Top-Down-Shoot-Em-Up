using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MaxHealth = 100f;
    public float CurrentHealth;
    public float maxSpeed = 5f;
    public float acceleration = 15f;
    public float BulletDamage = 12f;
    public int Piercing = 2;

    public static Player Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }



    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
    }

}