using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ScriptableObjectTrial", order =1)]
public class ScriptableObjectTrial : ScriptableObject
{
    public string prefabName;
    public int trialsxd;
    public Vector3[] spawnPoints;
    public List<GameObject> gameObjects;
}
