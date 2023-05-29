using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StaticStuff : MonoBehaviour
{
    public static AudioSource audioSource;

    public static GameObject player;
    public static GameObject ancla;
    public static GameObject touchObj;
    public static GameObject gameOverCanvas;
    public static GameObject canvas1;
    public static GameObject revivirCanvas;
  
    public static TextMeshProUGUI txt1;
    public static TextMeshProUGUI txt2;

    public static int x2 = 1;
    public static int powerDuration;
    public static float startTime;

    public static bool notActive = true;
    public bool personaje3;

    public static float timeDied;
    
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        player = GameObject.FindWithTag("Player");
        touchObj = GameObject.FindWithTag("Toque");
        ancla = GameObject.FindWithTag("Ancla"); 
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        revivirCanvas = GameObject.Find("Revivir");
        canvas1 = GameObject.Find("Canvas1");

        txt1 = GameObject.Find("StarsText").GetComponent<TextMeshProUGUI>();
        txt2 = GameObject.Find("ScoreInt").GetComponent<TextMeshProUGUI>();

        powerDuration = 4 + PlayerPrefs.GetInt("x2upg", 0);

        if (PlayerPrefs.GetInt("PersonajeSelecctionado", 0) == 4 || PlayerPrefs.GetInt("PersonajeSelecctionado", 0) == 5)
            personaje3 = true;
    }

    public static void GameOver()
    {
        if (player) player.SetActive(false);
        canvas1.SetActive(false);

        revivirCanvas.GetComponent<Animator>().SetTrigger("Died");
        revivirCanvas.SetActive(true);
        
        if (int.Parse(High.puntajeFinal) > PlayerPrefs.GetInt("HighScore", 0))
        {
            gameOverCanvas.transform.GetChild(13).gameObject.SetActive(true);
            PlayerPrefs.SetInt("HighScore", int.Parse(High.puntajeFinal));
        }
        gameOverCanvas.transform.GetChild(14).gameObject.GetComponent<TextMeshProUGUI>()
                    .text = PlayerPrefs.GetInt("HighScore").ToString("0");

        PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars", 0) 
                    + int.Parse(GameObject.Find("ScoreInt").GetComponent<TextMeshProUGUI>().text));
        txt1.text = PlayerPrefs.GetInt("Stars", 0).ToString();

        audioSource.mute = true;
        timeDied = Time.time;
    }

    public static void IncreaseScore(Vector2 _position, int scoreToIncrease)
    {
        Instantiate(GameObject.Find(scoreToIncrease.ToString()), 
                _position + Vector2.one/4, Quaternion.Euler(0, 0, -30));

        int newScore = int.Parse(txt1.text) + scoreToIncrease;
        txt1.text = newScore.ToString();
        txt2.text = txt1.text;
    }

    void Update()
    {
        if (x2 == 2)
        {
            if (startTime + powerDuration < Time.time)
            {
                x2 = 1;
            }
        }

        if (personaje3 && int.Parse(txt1.text) % PlayerPrefs.GetFloat("Poder2", 50) == 0 && notActive)
        {
            SolScript.invencible = true;
            SolScript.startTime = Time.time;

            notActive = false;
        }
    }
}
