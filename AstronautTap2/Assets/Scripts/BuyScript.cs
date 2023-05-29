using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyScript : MonoBehaviour
{
    //Make sure to attach these buyButtons in the Inspector
    public Button upgradeButton, selectBtn, selectBtn1, buyButton, buySkinBtn, skin1, skin2;
    public Button[] selectBtns;
    public Button[] skins;
    public Image[] upgradeImages;
    public float multipier;
    public float minusFactor;
    public TextMeshProUGUI secondsUpg;
    private TextMeshProUGUI upgradePrice, buyPrice, buyPrice2;
    public string personaje;

    public List<Button> buttons;

    void Awake()
    {
        foreach (Button btn in selectBtns)
        {
            buttons.Add(btn);
        }
        Debug.Log(buttons);

        if (buyButton) buyButton.onClick.AddListener(BuyCharacter);
        buySkinBtn.onClick.AddListener(() => BuySkin(buttons.IndexOf(selectBtn1)));

        upgradeButton.onClick.AddListener(UpgradeCharacter);
        selectBtn.onClick.AddListener(() => SelectCharacter(buttons.IndexOf(selectBtn)));
        selectBtn1.onClick.AddListener(() => SelectCharacter(buttons.IndexOf(selectBtn1)));

        skin1.onClick.AddListener(OnLeftSkinSelected);
        skin2.onClick.AddListener(OnRightSkinSelected);   
        if (PlayerPrefs.HasKey(personaje)) 
        {
            upgradeButton.interactable = true;
            SetDefaultValues();
        }
        else if (personaje != "1") 
        {
            skin1.interactable = false;
            skin2.interactable = false;
        }

        upgradePrice = transform.Find("UpgradeBtn").GetChild(0).GetComponent<TextMeshProUGUI>();
        buyPrice = transform.Find("Personaje/BuyBtn") ? 
                transform.Find("Personaje/BuyBtn").GetChild(0).GetComponent<TextMeshProUGUI>() : null;
        buyPrice2 = transform.Find("Personaje (1)/BuyBtn (1)").GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void BuyCharacter()
    {
        PlayerPrefs.SetString(personaje, "HasCharacter");

        SelectCharacter(buttons.IndexOf(selectBtn));
        SetDefaultValues();

        upgradeButton.interactable = true;
        PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars", 0) - int.Parse(buyPrice.text));
    }

    public void BuySkin(int index)
    {
        buySkinBtn.gameObject.SetActive(false);
        SelectCharacter(index);
        SetDefaultValues();

        PlayerPrefs.SetString(personaje, "HasSkin");
        PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars", 0) - int.Parse(buyPrice2.text));
    }

    void SetDefaultValues()
    {
        if (buyButton) buyButton.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt(personaje+"upg", 0) > 7) upgradeButton.interactable = false;
        if (PlayerPrefs.GetString(personaje) == "HasSkin")  buySkinBtn.gameObject.SetActive(false);

        for (int i = 0; i < PlayerPrefs.GetInt(personaje+"upg", 0); i++)
        {
            upgradeImages[i].color = Color.HSVToRGB(.4f, 1, 1);
        }

        switch (personaje)
        {
            case "1": 
                secondsUpg.text = $"<color=green>{50f + (PlayerPrefs.GetInt(personaje+"upg", 0)) * 6f}%</color> less pullback";
                break;
            case "2": 
                secondsUpg.text = $"stars have <color=green>{7 + (PlayerPrefs.GetInt(personaje+"upg", 0))*5}%</color> chance to worth double";
                break;
            case "3": 
                secondsUpg.text = $"you become invincible each <color=green>{50 - (PlayerPrefs.GetInt(personaje+"upg", 0))*3}</color> stars";
                break;
        }
        SelectCharacter(PlayerPrefs.GetInt("PersonajeSelecctionado", 0));
    }

    void SelectCharacter(int index)
    {
        for (int e = 0; e < selectBtns.Length; e++)
        {
            selectBtns[e].interactable = true;
            if (PlayerPrefs.HasKey(Mathf.Floor((e/2)+1).ToString())) skins[e].interactable = true;
        }
        selectBtns[index].interactable = false;
        skins[index].interactable = false;
        PlayerPrefs.SetInt("PersonajeSelecctionado", index);
    }

    void UpgradeCharacter()
    {
        if (PlayerPrefs.GetInt(personaje+"upg", 0) + 1 > 7) upgradeButton.interactable = false;
        else upgradePrice.text = Mathf.RoundToInt(int.Parse(upgradePrice.text) * multipier).ToString();

        multipier -= minusFactor;
        PlayerPrefs.SetInt(personaje+"upg", PlayerPrefs.GetInt(personaje+"upg", 0) + 1);

        switch (personaje)
        {
            case "1": 
                float pj1 = 50f + (PlayerPrefs.GetInt(personaje+"upg", 0)) * 6f;
                secondsUpg.text = $"<color=green>{pj1}%</color> less pullback";
                PlayerPrefs.SetFloat("Poder1", pj1);
                break;
            case "2": 
                float pj2 = 7 + (PlayerPrefs.GetInt(personaje+"upg", 0))*5;
                secondsUpg.text = $"stars have <color=green>{7 + (PlayerPrefs.GetInt(personaje+"upg", 0))*5}%</color> chance to worth double";
                PlayerPrefs.SetFloat("Poder2", pj2);
                break;
            case "3": 
                float pj3 = 50 - (PlayerPrefs.GetInt(personaje+"upg", 0))*3;
                secondsUpg.text = $"you become invincible each <color=green>{pj3}</color> stars";
                PlayerPrefs.SetFloat("Poder2", pj3);
                break;
        }

        for (int i = 0; i < PlayerPrefs.GetInt(personaje+"upg", 0); i++)
        {
            upgradeImages[i].color = Color.HSVToRGB(.4f, 1, 1);
        }

        PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") - int.Parse(upgradePrice.text));
    }

    void OnRightSkinSelected()
    {
        selectBtn1.gameObject.SetActive(true);
        selectBtn.gameObject.SetActive(false);

        skin2.interactable = false;
        skin1.interactable = true;
    }

    void OnLeftSkinSelected()
    {
        selectBtn.gameObject.SetActive(true);
        selectBtn1.gameObject.SetActive(false);

        skin1.interactable = false;
        skin2.interactable = true;
    }
}
