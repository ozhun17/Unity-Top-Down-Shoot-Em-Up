using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    public float minx;
    public float miny;
    public float maxx;
    public float maxy;



    private void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minx, maxx), Random.Range(miny, maxy));
        GameObject go = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        //PlayerManager.Instance.AddPlayer(go);
        //EnemySpawner.Instance.AddPlayer(go.transform, go.GetComponent<Player>().PlayerId);
    }

}
