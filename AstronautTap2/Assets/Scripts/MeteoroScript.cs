using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroScript : MonoBehaviour
{
    public Vector2 speed;
    private int random;
    //public Vector2 deltaPos;

    void Awake()
    {
        random = Random.Range(-60, 80);
    }

    void Start()
    {
        transform.rotation = Quaternion.Euler(0 ,0 , random);
        if (transform.position.x == 4) transform.localScale = new Vector3(-1, 1, 1);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x == -1) transform.Translate(-speed);
        else transform.Translate(speed);
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        Vector3 direction = collided.gameObject.transform.position - transform.position;
        collided.gameObject.GetComponent<Rigidbody2D>().velocity = -direction * 2/ direction.magnitude;
    }
}
