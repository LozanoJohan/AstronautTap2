using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fondo : MonoBehaviour
{
    public bool canvas;
    public Sprite[] fondos;
    private static Fondo fondo;
    public int index;
    // Start is called before the first frame update
    void Awake()
    {
        if (fondo == null) 
        {
            fondo = this;
            index = Random.Range(0, fondos.Length);
        }
        if (!canvas) GetComponent<SpriteRenderer>().sprite = fondos[fondo.index];
        else GetComponent<Image>().sprite = fondos[fondo.index];
        Debug.Log(index);
    }
}
