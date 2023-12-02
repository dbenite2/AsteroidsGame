// using UnityEngine;

// public class Player : MonoBehaviour {

//     public Bullet bulletPrefab;
//     public float thrustSpeed = 1.0f;
//     public float turnSpeed = 1.0f;
//     private Rigidbody2D _rigidBody;
//     private bool _thrusting;
//     private float _turnDirection;

//     private void Awake() {
//         _rigidBody = GetComponent<Rigidbody2D>();
//     }

//     private void Update() {
//         _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
//         if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
//             _turnDirection = 0.1f;
//         } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
//             _turnDirection = -0.1f;
//         } else {
//             _turnDirection = 0.0f;
//         }

//         if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
//             shoot();
//         }
//     }

//     private void FixedUpdate() {
//         if (_thrusting) {
//             _rigidBody.AddForce(transform.up * thrustSpeed);
//         }

//         if(_turnDirection != 0.0f) {
//             _rigidBody.AddTorque(_turnDirection * turnSpeed);
//         }
//     }
//     private void shoot() {
//         Bullet bullet = Instantiate(this.bulletPrefab,this.transform.position, this.transform.rotation);
//         bullet.Project(this.transform.up);
//     }
// }

