using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotEnoughMoney : MonoBehaviour
{
    public int price;
    public Button dependencia;
    private TextMeshProUGUI priceText;
    private Button thisBtn;

    void Awake()
    {
        priceText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        priceText.text = price.ToString();
        thisBtn = GetComponent<Button>();

        price = int.Parse(priceText.text);
        if ((PlayerPrefs.GetInt("Stars", 0)) < price) thisBtn.interactable = false;
    } 

    void Update()
    {
        price = int.Parse(priceText.text);
        if ((PlayerPrefs.GetInt("Stars", 0)) < price) thisBtn.interactable = false;
    }
}
