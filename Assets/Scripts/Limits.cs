using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limits : MonoBehaviour
{
    private WorldLimits worldLimits;
    // Start is called before the first frame update
    void Start()
    {
        worldLimits = GameController.instance.GetWorldLimits();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float x = transform.position.x;
        float y = transform.position.y;

        if (x > worldLimits.rightL) {
            position.x = worldLimits.leftL;
        }
        if (x < worldLimits.leftL) {
            position.x = worldLimits.rightL;
        }
        if (y > worldLimits.superiorL) {
            position.y = worldLimits.inferiorL;
        }
        if (y < worldLimits.inferiorL) {
            position.y = worldLimits.superiorL;
        }
        transform.position = position;
    }

}
