using UnityEngine;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform m_RectTransform;
    TextMeshProUGUI textMeshPro;
    float m_YAxis, yStart;
    float angulo = 0;
    public float scale = 1;

    void Start()
    {
        //Fetch the RectTransform from the GameObject
        m_RectTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        //Initiate the x and y positions
        yStart = m_RectTransform.anchoredPosition.y;
    }

    void Update()
    {
        angulo += .1f;
        //The Labels show what the Sliders represent
        m_YAxis = scale * Mathf.Sin(angulo) + yStart;
        m_RectTransform.anchoredPosition = new Vector2(0, m_YAxis);
        textMeshPro.color = Color.HSVToRGB((angulo/10)%1, 1, 1);
    }
}

