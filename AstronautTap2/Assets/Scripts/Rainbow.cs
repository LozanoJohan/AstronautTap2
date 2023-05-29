using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    private SpriteRenderer spriteR;
    public float saturation;
    public float value;
    private float hue;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hue += .1f;
        
        spriteR.color= Color.HSVToRGB((hue/10)%1, saturation, value);
    }
}
