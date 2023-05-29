using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neblina : MonoBehaviour
{
    public GameObject[] nieblaObjs;
    private int mostrarNiebla = 20; 
    private int i=0;
    private SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticStuff.player.transform.position.y > mostrarNiebla)
        {
            foreach (GameObject niebla in nieblaObjs)
            {
                StartCoroutine(MostrarNiebla());
                i++;
            }
            mostrarNiebla += 20;
            i=0;
        }
    }

    IEnumerator MostrarNiebla()
    {
        GameObject nieblaSpawned = Instantiate(nieblaObjs[i], Vector2.up * mostrarNiebla, Quaternion.Euler(0, 0, 90));
        SpriteRenderer m_SpriteRenderer = nieblaSpawned.GetComponent<SpriteRenderer>();
        Color color = new Color(1, 1, 1, 0);
        while (color.a < .3f)
        {
            color.a += 0.05f;
            m_SpriteRenderer.color = color;

            yield return new WaitForSeconds(1f);
        }
    }
}
