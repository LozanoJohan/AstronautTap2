using UnityEngine;

public class Walls : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.gameObject == Player.I.gameObject) GameManager.I.GameOver();
        else if (collided.gameObject.CompareTag(Tags.UNTAGGED)) Destroy(collided.gameObject);
    }
}
