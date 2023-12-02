using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AsteroidSpawner1 : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabAster;
    [SerializeField]
    private Transform[] spawners;
    [SerializeField]
    private float timeToSpawn = 2.0f;
    private int poolPosition;
    // Start is called before the first frame update
    void Start()
    {
        poolPosition = ObjectPooler.instance.SearchPool(prefabAster);
        StartCoroutine(Spawn());
    }

    // use co-routines

    private IEnumerator Spawn() {
        while(true) {
            int randomSpawner = Random.Range(0,spawners.Length);
            if (poolPosition == -1) {
                Debug.LogError("AsteroidSpawner_1::Spawn No prefab was passed");
                yield return null;
            }
            GameObject asteroid = ObjectPooler.instance.GetPooledObject(poolPosition);
            asteroid.transform.position = spawners[randomSpawner].position;
            asteroid.transform.rotation = Quaternion.identity;
            asteroid.SetActive(true);
            // Instantiate(prefabAster, spawners[randomSpawner].position, Quaternion.identity);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
