using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesShop : MonoBehaviour
{
    public Button upgradeButton;
    public Image[] upgradeImages;
    public TextMeshProUGUI upgradePrice;
    public TextMeshProUGUI upgradedTime;
    public float multipier;
    public float minusFactor;
    public string item;
    private string endS = "upg";
    // Start is called before the first frame update
    void Awake()
    {
        if(PlayerPrefs.HasKey(item+endS)) SetDefaultValues();
        upgradeButton.onClick.AddListener(Upgrade);
    }

    void Upgrade()
    {
        if (PlayerPrefs.GetInt(item+endS, 0) + 1 > 7) upgradeButton.interactable = false;
        PlayerPrefs.SetInt(item+endS, PlayerPrefs.GetInt(item+endS, 0) + 1);
        
        for (int i = 0; i < PlayerPrefs.GetInt(item+endS, 0); i++)
        {
            upgradeImages[i].color = Color.HSVToRGB(.14f, 1, 1);;
        }

        PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") - int.Parse(upgradePrice.text));
        upgradePrice.text = Mathf.RoundToInt(int.Parse(upgradePrice.text) * multipier).ToString();

        upgradedTime.text = $"{4 + PlayerPrefs.GetInt(item+endS, 0)} seconds";
        multipier -= minusFactor;
    }

    void SetDefaultValues()
    {
        if (PlayerPrefs.GetInt(item+endS, 0) > 7) upgradeButton.interactable = false;
        for (int i = 0; i < PlayerPrefs.GetInt(item+endS, 0); i++)
        {
            upgradeImages[i].color = Color.HSVToRGB(.14f, 1, 1);
        }
        upgradedTime.text = $"{4 + PlayerPrefs.GetInt(item+endS, 0)} seconds";
    }
}
