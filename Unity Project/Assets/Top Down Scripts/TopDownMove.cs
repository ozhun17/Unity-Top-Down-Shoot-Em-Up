using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMove : MonoBehaviour
{

    private float maxSpeed;
    private float acceleration;
    public Joystick _joystick;
    private Vector2 desDirection;
    private Vector2 desSpeed;
    public Vector2 velocity;
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    public int inputStyle;
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        maxSpeed = _player.maxSpeed;
        acceleration = _player.acceleration;
    }

    private void Update()
    {
        switch (inputStyle)
        {
            case 0:
                desDirection.x = _joystick.Horizontal;
                desDirection.y = _joystick.Vertical;
                break;
            case 1:
                desDirection.x = Input.GetAxis("Horizontal");
                desDirection.y = Input.GetAxis("Vertical");
                break;
        }
        desSpeed = new Vector2(desDirection.x, desDirection.y);
        desSpeed.Normalize();
        desSpeed *= maxSpeed;

    }

    private void FixedUpdate()
    {
        velocity = _rigidbody.velocity;
        if (desSpeed.x == 0 && desSpeed.y == 0 && velocity.x == 0 && velocity.y == 0) { return; }
        velocity.x = Mathf.MoveTowards(velocity.x, desSpeed.x, acceleration);
        velocity.y = Mathf.MoveTowards(velocity.y, desSpeed.y, acceleration);
        if (_rigidbody.velocity.x < 0f) { _transform.rotation = Quaternion.Euler(0f, 0f, 0f); }
        else { _transform.rotation = Quaternion.Euler(0f, 180f, 0f); }
        _rigidbody.velocity = velocity;
    }
}
