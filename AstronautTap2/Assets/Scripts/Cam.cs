using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour
{
    private Vector2 distanceToPlayer;

    private Transform playerTrs;

    void Start()
    {
        playerTrs = Player.I.gameObject.transform;
    }
    void Update()
    {
        Vector3 position = transform.position;
        position.x = 0;
        position.z = -10;
        transform.position = position;
    }

    void FixedUpdate()
    {
        if (playerTrs.gameObject.activeSelf)
        {
            if (playerTrs.position.y + 2 - transform.position.y > 0)
            {
                distanceToPlayer = playerTrs.position - transform.position;
                transform.position = Vector2.MoveTowards(transform.position,
                        (Vector2)playerTrs.position + 2 * Vector2.up, distanceToPlayer.magnitude * Time.deltaTime * 2f);
            }

        }
    }
}
