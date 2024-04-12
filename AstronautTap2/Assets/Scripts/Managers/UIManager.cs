using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager I;
    [Header("Canvas")]
    public GameObject gameOverCanvas;
    public GameObject gameCanvas;
    public GameObject revivirCanvas;
    public GameObject menuCanvas;

    [Header("Texts")]
    //public TextMeshProUGUI totalStartsText;
    //public TextMeshProUGUI totalStartsText2;
    public TextMeshProUGUI starsCountText;
    [Header("Revive Config")]
    public Button reviveBtn;
    public Slider reviveSlider;
    public float reviveSliderDuration;

    [Header("Power Sliders")]
    public Slider magnetSlider;
    public Slider goldSlider;
    public Slider invincibleSlider;
    public Slider x2Slider;

    [Header("Others")]
    public GameObject newHighScoreP;
    public TextMeshProUGUI highScoreText, heightText, heightText2, finalScoreText;

    void Awake()
    {
        if (I == null) I = this;
    }

    public void ShowGameOver()
    {
        gameCanvas.SetActive(false);         // Desactivar canvas de pausa 

        revivirCanvas.GetComponent<Animator>().SetTrigger("Died");  // Empezar animación de muerte en el canvas
        revivirCanvas.SetActive(true);
    }

    public void ShowMenu()
    { }

    public void ShowGameCanvas()
    {
        gameCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }
    public void UpdateHighScoreText()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void SetHeightText(float height)
    {
        heightText.text = height.ToString("0");
        heightText2.text = height.ToString("0");
    }
    public void SetFinalScoreText(int finalScore)
    {
        finalScoreText.text = finalScore.ToString();
    }
    public void SetStarsCountText(int stars)
    {
        starsCountText.text = stars.ToString("0");
    }

    public void ShowReviveSlider(float startTime)
    {
        SetSliderValue(reviveSlider, startTime, reviveSliderDuration);
        if (reviveSlider.value == 0 && !Player.I.gameObject) reviveBtn.interactable = false;
    }

    public void ShowScoreImage(int score, Vector2 pos)
    {
        // Muestra la imagen correspondiente al score aumentado.
        GameObject scoreImage = GameObject.Find(score.ToString());

        Vector2 positionToInstantiate = pos + Vector2.up / 4;
        Quaternion rotationToInstantiate = Quaternion.Euler(0, 0, -30);

        Instantiate(scoreImage, positionToInstantiate, rotationToInstantiate);

    }
    public void ShowHighScore()
    {
        newHighScoreP.SetActive(true);
    }
    void Update()
    {
        if (PowerUpsManager.I.MagnetPower.StartTime != 0)
            SetSliderValue(magnetSlider, PowerUpsManager.I.MagnetPower.StartTime, PowerUpsManager.I.MagnetPower.PowerDuration);
        if (PowerUpsManager.I.InvincibilityPower.StartTime != 0)
            SetSliderValue(invincibleSlider, PowerUpsManager.I.InvincibilityPower.StartTime, PowerUpsManager.I.InvincibilityPower.PowerDuration);
        if (PowerUpsManager.I.X2Power.StartTime != 0)
            SetSliderValue(x2Slider, PowerUpsManager.I.X2Power.StartTime, PowerUpsManager.I.X2Power.PowerDuration);
        if (PowerUpsManager.I.GoldPower.StartTime != 0)
            SetSliderValue(goldSlider, PowerUpsManager.I.GoldPower.StartTime, PowerUpsManager.I.GoldPower.PowerDuration);
    }

    public void UpdateTotalStarsCountText()
    {
        //totalStartsText2.text = PlayerPrefs.GetInt("Stars", 0).ToString();
    }

    public static void SetSliderValue(Slider slider, float startTime, float duration)
    {
        slider.value = (startTime + duration - Time.time) / duration;
    }
}