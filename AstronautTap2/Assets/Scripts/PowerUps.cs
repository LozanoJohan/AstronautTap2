using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool setIndex;
    public int index;
    private SpriteRenderer spriteR;
    public Sprite[] sprites;
    private Rainbow rainbow;
    private RotationScript rotation;
    public static float timeIman = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!setIndex) index = Random.Range(0, sprites.Length);
        rainbow = GetComponent<Rainbow>();
        rotation = GetComponent<RotationScript>();
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = sprites[index];

        switch (index)
        {
            case 1:
                rainbow.enabled = true;
                break;
            case 2:
                rainbow.enabled = true;
                rotation.enabled = true;
                break;
            case 3:
                spriteR.color = new Color(255, 102, 0);
                break;
        }
    }



    
}
