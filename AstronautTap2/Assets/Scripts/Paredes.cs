using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.gameObject == StaticStuff.player) StaticStuff.GameOver();
        else if (collided.gameObject.tag == "Untagged") Destroy(collided.gameObject);
    }
}
