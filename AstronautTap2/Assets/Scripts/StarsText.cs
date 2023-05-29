using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsText : MonoBehaviour
{
    private TextMeshProUGUI stars;
    // Start is called before the first frame update
    void Start()
    {
        stars = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        stars.text = PlayerPrefs.GetInt("Stars", 0).ToString();
    }
}
