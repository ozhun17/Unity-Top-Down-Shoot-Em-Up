using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour, IPooledObject
{
    public float bulletSpeed;
    private Rigidbody2D _rb;
    private float BulletDamage = 10f;
    private int Piercing = 1;
    private Player _player;
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
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
    }

}
