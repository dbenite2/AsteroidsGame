using UnityEngine;

public class Shooting : MonoBehaviour {
    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private Transform _transform;

    private bool isShooting = false;

    private int poolPosition;

    void Start() {
        poolPosition = ObjectPooler.instance.SearchPool(_bullet);
    }

    void Update() {
        isShooting = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
        shoot();
    }

    private void shoot() {
        if(isShooting) {
            // Instantiate(_bullet, _transform.position, _transform.rotation);
            if (poolPosition == -1) {
                Debug.LogError("Shooting::shoot No prefab was passed");
                return;
            }

            GameObject bullet = ObjectPooler.instance.GetPooledObject(poolPosition);
            bullet.transform.position = _transform.position;
            bullet.transform.rotation = _transform.rotation;
            bullet.SetActive(true);
        }
    }
}