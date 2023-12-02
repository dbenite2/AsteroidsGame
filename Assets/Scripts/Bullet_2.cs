using UnityEngine;

public class Bullet_2 : MonoBehaviour
{
    [SerializeField]
    private float speed = 20.0f;
    [SerializeField]
    private float maxLifetime = 10.0f;
    private float count = 0;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        count = maxLifetime;
    }

    private void OnEnable() {
        count = maxLifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if(count > 0) {
            count -= Time.deltaTime;
        } else {
            gameObject.SetActive(false);
        }
        _transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        gameObject.SetActive(false);
    }
}
