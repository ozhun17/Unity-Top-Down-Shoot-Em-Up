using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform PlayerTransform;
    private IEnumerator coroutine;
    public float waitTime = 2f;
    private void Awake()
    {
        PlayerTransform = GetComponent<Transform>();
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
            ObjectPooler.Instance.SpawnFromPool("enemy", PlayerTransform.position, PlayerTransform.rotation);
        }
    }
}
