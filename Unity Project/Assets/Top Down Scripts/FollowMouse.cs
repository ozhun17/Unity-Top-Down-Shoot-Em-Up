using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 screenposition;
    private Vector3 worldposition;

    void Update()
    {
        screenposition = Input.mousePosition;
        worldposition = Camera.main.ScreenToWorldPoint(screenposition);
        worldposition.z = 0f;
        transform.position = worldposition;
    }
}
