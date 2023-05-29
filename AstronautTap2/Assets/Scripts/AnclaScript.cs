using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AnclaScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 position;
    public GameObject touch;
    public GameObject player;
    public Sprite[] sprites;
    private float time;
    private bool personaje2;

    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerPrefs.GetInt("PersonajeSelecctionado", 0) == 2 || PlayerPrefs.GetInt("PersonajeSelecctionado", 0) == 3)
            personaje2 = true;
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    
    void LateUpdate()
    {
        lineRenderer.SetPosition(0, StaticStuff.player.transform.position);

        time = (Time.time - TouchScript.startTime) * 4f;
        position = Vector2.Lerp(lineRenderer.GetPosition(0), StaticStuff.touchObj.transform.position, time);
        lineRenderer.SetPosition(1, position);
    }

    void Update()
    {   
        if (Vector2.Distance(lineRenderer.GetPosition(1), touch.transform.position) < .1f && TouchScript.touchedObj != null)
        {
            if (TouchScript.touchedObj.tag == "Estrella")
            {   
                if (personaje2 && (int)UnityEngine.Random.Range(0, 100) <= PlayerPrefs.GetFloat("Poder2", 7)) 
                    StaticStuff.IncreaseScore(TouchScript.touchedObj.transform.position, 2);

                else StaticStuff.IncreaseScore(TouchScript.touchedObj.transform.position, 1 * StaticStuff.x2);

                QuitAncla();
            }
            else if (TouchScript.touchedObj.tag == "PowerUp")
            {
                Sprite[] posibleSprites = TouchScript.touchedObj.GetComponent<PowerUps>().sprites;
                Sprite actualSprite = TouchScript.touchedObj.GetComponent<SpriteRenderer>().sprite;

                if (posibleSprites[0] == actualSprite) 
                {
                    EstrellaScript.move = true;
                    EstrellaScript.startTime = Time.time;
                }
                else if (posibleSprites[1] == actualSprite)
                {
                    SolScript.invencible = true;
                    SolScript.startTime = Time.time;
                }
                else if (posibleSprites[2] == actualSprite)
                {
                    StaticStuff.x2 = 2;
                    StaticStuff.startTime = Time.time;
                }
                else if (posibleSprites[3] == actualSprite)
                {
                    AsteroideScript.gold = true;
                    AsteroideScript.startTime = Time.time;
                }
                        
                QuitAncla();
            }
            else
            {
                float distancia = Vector2.Distance(touch.transform.position, player.transform.position);
                player.transform.position = Vector2.MoveTowards(player.transform.position, touch.transform.position, 
                        7 * distancia * Time.deltaTime + 0.1f);
            }
        }
    }

    void QuitAncla()
    {
        StaticStuff.touchObj.transform.parent = StaticStuff.player.transform;
        TouchScript.touchedObj.SetActive(false);
        gameObject.SetActive(false);
    }
}
