using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunTransform;
    private Player _player;
    private int playerId;

    private void Awake()
    {
        _player = GetComponent<Player>();
        playerId = _player.PlayerId;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ObjectPooler.Instance.SpawnFromPool("bullet", gunTransform.position, gunTransform.rotation, playerId);
        }
    }
}
