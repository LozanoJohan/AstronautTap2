using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    [SerializeField] float xLength;
    [SerializeField] float yLength;
    public bool negative;
    private Vector2 startPosition;
    // Update is called once per frame
    void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (!negative)
            transform.position = new Vector2(Mathf.PingPong(Time.time, xLength), 
                                Mathf.PingPong(Time.time, yLength)) + startPosition;
        else
            transform.position = new Vector2(-Mathf.PingPong(Time.time, xLength), 
                                Mathf.PingPong(Time.time, yLength)) + startPosition;
    }
}
