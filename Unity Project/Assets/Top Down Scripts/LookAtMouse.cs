using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Start is called before the first frame update
    public Joystick _joystick;
    private float angle;
    public int inputStyle; // 0 for joystick 1 for mouse
    private SpriteRenderer GunSprite;


    private void Awake()
    {
        GunSprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        switch (inputStyle)
        {
            case 0:
                angle = Mathf.Atan2(_joystick.Vertical, _joystick.Horizontal) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                break;
            case 1:
                var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                if(dir.x < 0) { GunSprite.flipY = true; }
                else { GunSprite.flipY = false;}
                break;
        }
        
       


    }
}
