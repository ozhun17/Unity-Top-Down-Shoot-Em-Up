using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetChanger : MonoBehaviour
{
    public LayerMask enemyLayer;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.PlayerTransform = this.transform.parent;
            Debug.Log("triggertrial");
        }
    }
}
