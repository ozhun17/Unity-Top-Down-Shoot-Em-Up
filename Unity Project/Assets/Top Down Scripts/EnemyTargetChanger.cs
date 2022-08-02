using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetChanger : MonoBehaviour
{
    private Enemy _enemy;
    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            _enemy.PlayerTransform = collision.transform;
        }
    }
}
