using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public bool setRandom;
    public Sprite[] backgrounds;
    public GameObject background;
    public int index;
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        if (setRandom)
            index = Random.Range(0, backgrounds.Length);

        background.GetComponent<SpriteRenderer>().sprite = backgrounds[index];
    }
}
