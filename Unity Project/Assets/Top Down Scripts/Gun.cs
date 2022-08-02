using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform gunTransform;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ObjectPooler.Instance.SpawnFromPool("bullet", gunTransform.position, gunTransform.rotation);
        }
    }
}
