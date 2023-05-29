using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPivot : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    public Transform pivotObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(pivotObject.position, Vector3.forward, rotationSpeed * Time.deltaTime * 20f);
    }
}
