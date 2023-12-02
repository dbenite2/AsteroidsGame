using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Class_Asteroid : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private int score = 5;

    [SerializeField]
    private Vector2 goal;

    [SerializeField]
    private float size = 3.0f;
    [SerializeField]
    private float minSize = 0.5f;

    private Vector2 distance;
    
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    void OnEnable() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        transform.localScale = Vector3.one * size;
        _rigidbody.mass = size;
        rotation();
        _rigidbody.AddForce(speed * _transform.right, ForceMode2D.Force);
    }

   private void rotation() {
        Vector2 objectPosition = _transform.position;
        distance.x = goal.x -objectPosition.x;
        distance.y = goal.y - objectPosition.y;

        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.Euler(new Vector3(0,0, angle));
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Bullet") {
            collider.gameObject.SetActive(false);
            GameController.instance.ScoreUp(score);
            if ((size * 0.5f) > minSize) {
                Split(0);
                Split(1);
            }
            gameObject.SetActive(false);
        }
    }

    private void Split(int spriteSize) {
        Vector2 position = _transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Class_Asteroid half = Instantiate(this, position, _transform.rotation);
        half.size = size * 0.5f;
        half._spriteRenderer.sprite = sprites[spriteSize];
        half.SetTrajectory(Random.insideUnitCircle.normalized);
    }

    private void SetTrajectory(Vector2 direction) {
        _rigidbody.AddForce(direction * speed);
    }
    
}
