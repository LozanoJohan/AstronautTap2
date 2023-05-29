using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class High : MonoBehaviour
{
    public TextMeshProUGUI textTMPRO;
    public TextMeshProUGUI textTMPRO2;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI textStars;
    public int altura; 
    public static string puntajeFinal;

    void Update()
    {
        altura = (int)StaticStuff.player.transform.position.y;
        textTMPRO.text = altura < 0 ? "0" : altura.ToString();
        textTMPRO2.text = textTMPRO.text;

        finalScore.text = (altura + int.Parse(textStars.text) * 2).ToString();
        puntajeFinal = finalScore.text;
    }
}
