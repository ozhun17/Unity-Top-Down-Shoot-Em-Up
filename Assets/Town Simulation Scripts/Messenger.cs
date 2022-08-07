using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messenger : MonoBehaviour
{
    public float moveSpeed = 1f;
    public int neededResourceType = 0;
    public int neededResourceQuantity = 1;
    public int messageSent = 0;
    private Vector2 direction;
    [SerializeField] private Transform toWhichTown;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void StartJourney()
    {
        direction = new Vector2(toWhichTown.position.x - _transform.position.x, toWhichTown.position.y - _transform.position.y);
        direction.Normalize();
        _rigidbody.velocity = new Vector3(direction.x, direction.y);
        _rigidbody.velocity = _rigidbody.velocity * moveSpeed;
    }

    private void Start()
    {
        StartJourney();
    }
}
