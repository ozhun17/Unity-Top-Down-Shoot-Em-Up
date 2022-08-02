using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{

    public float MaxHealth = 100f;
    public float CurrentHealth;
    public float MoveSpeed = 2f;
    public Transform PlayerTransform;
    private Transform _transform;
    private Vector2 Direction;
    private Rigidbody2D _rigidbody;
    private Player _player;
    public GameObject damageTextPrefab;
    public int TextDestroyTime = 1;
    private Vector2 randomPoint;
    public LayerMask playerLayer;
    private Vector2 skip;
    public int skipRadius = 8;

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
        randomPoint = Random.insideUnitCircle.normalized;
        if (randomPoint == Vector2.zero) { randomPoint = Vector2.one; };
        randomPoint *= skipRadius;
        skip = randomPoint;
        randomPoint = new Vector2(randomPoint.x + PlayerTransform.position.x, randomPoint.y + PlayerTransform.position.y);
        int checker = CheckForPlayers(randomPoint);
        while(checker == 1)
        {
            randomPoint += skip;
            checker = CheckForPlayers(randomPoint);
        }
        _transform.position = randomPoint;
    }


    private int CheckForPlayers(Vector2 Point)
    {
        Collider2D hit = Physics2D.OverlapCircle(Point, skipRadius-2, playerLayer);
        if(hit != null)
        {
            return 1;
        }
        return 0;
    }

}
