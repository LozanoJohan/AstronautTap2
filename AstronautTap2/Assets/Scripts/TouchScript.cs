using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchScript : MonoBehaviour
{
    private Vector2 touchedVelocity;
    private Rigidbody2D rigidBody2D;
    public static float startTime;
    private Vector2 position;
    private LineRenderer anclaLine;
    public static GameObject touchedObj;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        anclaLine = StaticStuff.ancla.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void EarlyUpdate()
    {
        if (touchedObj == null) 
        {
            gameObject.SetActive(false);
            StaticStuff.ancla.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.gameObject.tag == "Player") 
        {
            gameObject.SetActive(false);
        } 
        else 
        {
            touchedObj = collided.gameObject;
            touchedVelocity = touchedObj.GetComponent<Rigidbody2D>().velocity;
        }
        startTime = Time.time;
    }

    void OnTriggerStay2D(Collider2D collided)
    {
        transform.parent = collided.gameObject.transform;
        anclaLine.gameObject.SetActive(true);
        
        rigidBody2D.velocity = touchedVelocity;
    }

    void OnTriggerExit2D(Collider2D collided)
    {
        touchedObj = null;
    }
}