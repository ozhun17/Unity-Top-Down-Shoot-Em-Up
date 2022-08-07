using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour, IPooledObject
{
    private float bulletSpeed = 2;
    private Rigidbody2D _rb;
    private float BulletDamage = 10f;
    private int Piercing = 1;
    private Player _player;
    public LayerMask GroundLayer;
    // Start is called before the first frame update
    private void Start()
    {
        OnObjectSpawn(0);
    }

    public void OnObjectSpawn(int Variable)
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.right * bulletSpeed;
        _player = PlayerManager.Instance.Players[Variable].PlayerGameObject.GetComponent<Player>();  //BulletDamage;
        BulletDamage = _player.BulletDamage;
        bulletSpeed = _player.BulletSpeed;
        Piercing = _player.Piercing;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage((int)BulletDamage);
            Piercing--;
            if(Piercing <= 0)
            {
                this.gameObject.SetActive(false);
            }
            return;
        }
        if(collision.gameObject.layer == GroundLayer)
        {
            this.gameObject.SetActive(false);
        }
        
    }

}
