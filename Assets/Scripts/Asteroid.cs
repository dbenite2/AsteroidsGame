// using UnityEngine;

// public class Asteroid : MonoBehaviour
// {
//     public float size = 3.0f;
//     public float minSize = 0.5f;
//     public float maxSize = 3.0f;
//     public float speed = 25.0f;
//     public float maxLifetime = 30.0f;
//     public Sprite[] sprites;
//     private SpriteRenderer _spriteRenderer;
//     private Rigidbody2D _rigidbody;

//     private void Awake() {
//         _spriteRenderer = GetComponent<SpriteRenderer>();
//         _rigidbody = GetComponent<Rigidbody2D>();
//     }

//     private void Start() {
//         transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
//         transform.localScale = Vector3.one * size;
//         _rigidbody.mass = size;
//     }

//     public void setTrajectory(Vector2 direction) {
//         _rigidbody.AddForce(direction * speed);
//         Destroy(gameObject, maxLifetime);
//     }

//     private void Split () {
//         Vector2 position = transform.position;
//         position += Random.insideUnitCircle * 0.5f;
//         Asteroid half = Instantiate(this, position, transform.rotation);
//         half.size = size * 0.5f;
//         half.setTrajectory(Random.insideUnitCircle.normalized );
//     }

//     private void OnCollisionEnter2D(Collision2D collision) {
//         if (collision.gameObject.tag == "Bullet") {
//             if ((size * 0.5f) > minSize) {
//                 Split();
//                 Split();
//             }
//             Destroy(gameObject);
//         }
//     }
// }
