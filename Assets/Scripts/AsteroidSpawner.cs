// using UnityEngine;

// public class AsteroidSpawner : MonoBehaviour
// {
//     public float trajectoryVariance = 15.0f;
//     public Asteroid asteroidPrefab;
//     public float spawnDistance = 15.0f;
//     public float spawnRate = 2.0f;
//     public int spawnAmmount = 1;
//     private void Start() {
//         InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
//     }

//     private void Spawn() {
//         for(int i = 0; i < spawnAmmount; i++) {

//             Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
//             Vector3 spawnPoint = this.transform.position + spawnDirection;
//             float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
//             Quaternion rotation =  Quaternion.AngleAxis(variance, Vector3.forward);
//             Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
//             asteroid.setTrajectory(rotation * -spawnDirection);
//         }
//     }

// }
