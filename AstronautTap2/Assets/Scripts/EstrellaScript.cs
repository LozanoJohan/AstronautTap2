using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EstrellaScript : MonoBehaviour
{
    public static bool move;
    public static float startTime = 0;
    public GameObject spiral;
    public SpriteRenderer spriteSpiral;

    public static int powerDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        spiral = GameObject.Find("Espiral");
        spriteSpiral = spiral.GetComponent<SpriteRenderer>();

        powerDuration = 4 + PlayerPrefs.GetInt("magnetupg", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            if (startTime + powerDuration > Time.time)
            {
                spriteSpiral.color = Color.Lerp(spriteSpiral.color, new Color(1, 0, 1, .4f), Time.deltaTime);

                if (Vector2.Distance(transform.position, StaticStuff.player.transform.position) < 3)
                    transform.position = Vector2.MoveTowards(transform.position, StaticStuff.player.transform.position, 5 * Time.deltaTime);
            }
            else
            {
                spriteSpiral.color = Color.Lerp(spriteSpiral.color, new Color(1, 0, 1, 0), Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collided)
    {   if (collided.gameObject == StaticStuff.touchObj || collided.gameObject.tag == "PowerUp") return;
        else if (collided.gameObject.tag == "Player")
        {
            StaticStuff.IncreaseScore(transform.position, 1 * StaticStuff.x2);
        }
        gameObject.SetActive(false);
    }
}
