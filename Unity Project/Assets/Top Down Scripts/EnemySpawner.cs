using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform PlayerTransform;
    private IEnumerator coroutine;
    private float waitTime = 2f;
    private Player _player;
    private int playerid;
    private void Awake()
    {
        PlayerTransform = GetComponent<Transform>();
        _player = GetComponent<Player>();
        playerid = _player.PlayerId;
        waitTime = _player.EnemySpawnWaitTime;
    }

    private void Start()
    {
        coroutine = SpawnEnemy(waitTime);
        StartCoroutine(coroutine);
    }

    private IEnumerator SpawnEnemy(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            ObjectPooler.Instance.SpawnFromPool("enemy", PlayerTransform.position, PlayerTransform.rotation, playerid);
            waitTime = _player.EnemySpawnWaitTime;
        }
    }
}
