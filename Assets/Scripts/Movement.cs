using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float maxSpeed = 20.0f;
    private float vertical;
    private Rigidbody2D _rigidbody;
    private Transform  _transform;
    // Start is called before the first frame update
    void Start() {
    	_rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        rotate();
    }

    private void FixedUpdate() {
        move();
    }

    private void move() {
        _rigidbody.AddForce(speed * _transform.right * vertical, ForceMode2D.Force);
        if (_rigidbody.velocity.magnitude > maxSpeed) {
            _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
        }
    }

    private void rotate() {

        // lookAt function
        Vector2 mousePosition = Input.mousePosition;
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(_transform.position);
        mousePosition.x -= objectPosition.x;
        mousePosition.y -= objectPosition.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

}
