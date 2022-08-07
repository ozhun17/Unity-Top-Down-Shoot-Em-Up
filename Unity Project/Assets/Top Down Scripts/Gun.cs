using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunTransform;
    private Player _player;
    private int playerId;
    private int projectiles = 1;
    private float bulletSpread = 15;
    private Quaternion bulletTransform;

    private void Awake()
    {
        _player = GetComponent<Player>();
        playerId = _player.PlayerId;
        projectiles = _player.Projectiles;
        bulletSpread = _player.BulletSpread;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    private void Shoot()
    {
        float angletorotate = bulletSpread / (projectiles + 1);

        GetAngleFromGun(bulletSpread);
        for (int i = 0; i < projectiles; i++)
        {
            bulletTransform *= Quaternion.AngleAxis(angletorotate, Vector3.forward);



            ObjectPooler.Instance.SpawnFromPool("bullet", gunTransform.position, bulletTransform, playerId);

        }
    }

    private void GetAngleFromGun(float bulletspread)
    {
        ;
        bulletTransform = gunTransform.rotation;
        bulletTransform *= Quaternion.AngleAxis((-bulletspread/2), Vector3.forward);

    }
}
