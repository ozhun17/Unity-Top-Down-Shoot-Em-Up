using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{

    public float MaxHealth = 100f;
    public float CurrentHealth;
    public float MoveSpeed = 2f;
    private Transform PlayerTransform;
    private Transform _transform;
    private Vector2 Direction;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        PlayerTransform = Player.Instance.GetComponent<Transform>();
        _transform = GetComponent<Transform>();
        CurrentHealth = MaxHealth;
        OnObjectSpawn();

    }


    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }
    private void MoveTowardsPlayer()
    {
        Direction = new Vector2(PlayerTransform.position.x - _transform.position.x, PlayerTransform.position.y - _transform.position.y);
        Direction.Normalize();
        Direction *= MoveSpeed;
        _rigidbody.velocity = Direction;
        
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        if(CurrentHealth < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    
    public void OnObjectSpawn()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        PlayerTransform = Player.Instance.GetComponent<Transform>();
        _transform = GetComponent<Transform>();
        CurrentHealth = MaxHealth;
        _transform.position = new Vector2(PlayerTransform.position.x+5, PlayerTransform.position.y+5);
    }
}
