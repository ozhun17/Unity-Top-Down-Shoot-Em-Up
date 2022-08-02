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
    private Player _player;
    public GameObject damageTextPrefab;
    public int TextDestroyTime = 1;

    private void Start()
    {
        OnObjectSpawn(0);

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
        if (damageTextPrefab != null && CurrentHealth > 0)
        {
            ShowDamageText((int)CurrentHealth);
        }
        if(CurrentHealth < 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void ShowDamageText(int numToShow)
    {
        ObjectPooler.Instance.SpawnFromPool("damagetext", transform.position, Quaternion.identity, numToShow);
    }
    
    public void OnObjectSpawn(int Variable)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = PlayerManager.Instance.Players[Variable].PlayerGameObject.GetComponent<Player>();
        PlayerTransform = _player.GetComponent<Transform>();
        _transform = GetComponent<Transform>();
        CurrentHealth = MaxHealth;
        _transform.position = new Vector2(PlayerTransform.position.x+5, PlayerTransform.position.y+5);
    }
}
