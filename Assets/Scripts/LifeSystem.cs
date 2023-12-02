using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    [SerializeField]
    private float respawnTime = 1.5f;

    [SerializeField]
    private GameObject shipModel;

    private bool alive = true;

    private Coroutine _playerDeath;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Asteroid" && alive) {
                if (GameController.instance.PlayerDie()) {
                    alive = false;
                    _playerDeath = StartCoroutine(DieAndRevive());
                }
        }
    }

    private IEnumerator DieAndRevive() {
        while(!alive) {
            shipModel.SetActive(false);
            yield return new WaitForSeconds(respawnTime);
            transform.position = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            shipModel.SetActive(true);

            GameController.instance.Replay();
            alive = true;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
