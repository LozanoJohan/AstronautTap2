using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRandom : MonoBehaviour
{
    public float staruration = .8f;
    public float value = 1f;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float hue = Random.Range(0, 1f);
        spriteRenderer.color = Color.HSVToRGB(hue, staruration, value);
    }
}
