using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private int collisionTimes = 0;
    private int goldAsteroid;
    public GameObject lightPrefab;
    public float speed = 1f;
    public Sprite damagedAsteroid;
    public static bool gold = false;
    public static float startTime;
    public static int powerDuration;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();

        powerDuration = 4 + PlayerPrefs.GetInt("goldupg", 0);

        goldAsteroid = Random.Range(0, 20);
        if (goldAsteroid == 3)
        {
            spriteRenderer.color = Color.yellow;
            GameObject light = Instantiate(lightPrefab, transform.position, Quaternion.identity);
            light.transform.parent = transform;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (gold)
        {
            if (startTime + powerDuration > Time.time)  
            {
                goldAsteroid = 3;
                spriteRenderer.color = Color.yellow;
                if (transform.childCount == 0) 
                {
                    GameObject light = Instantiate(lightPrefab, transform.position, Quaternion.identity);
                    light.transform.parent = transform;
                }
            }
            else 
            {
                goldAsteroid = 2;
                spriteRenderer.color = Color.white;
                transform.GetChild(0).gameObject.SetActive(false);
                gold = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        if (collided.gameObject == StaticStuff.player) collisionTimes++;
        switch (collisionTimes)
        {
            case 1:
                spriteRenderer.sprite = damagedAsteroid;
                break;

            case 2:
                if (StaticStuff.touchObj.transform.IsChildOf(transform))
                {
                    StaticStuff.touchObj.transform.parent = StaticStuff.player.transform;
                    StaticStuff.touchObj.SetActive(false);
                    StaticStuff.ancla.SetActive(false);
                }
                if (goldAsteroid == 3) StaticStuff.IncreaseScore(transform.position, 2 * StaticStuff.x2);

                gameObject.SetActive(false);
                break;
        }
      
        Vector3 direction = collided.gameObject.transform.position - transform.position;
        rigidBody2D.velocity = -direction * speed / direction.magnitude;
    }
}
