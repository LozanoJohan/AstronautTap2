using System.Collections;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public GameObject[] nieblaObjs;
    private int mostrarNiebla = 20; 
    private int i=0;
    private SpriteRenderer m_SpriteRenderer;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = Player.I.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float playerY = player.transform.position.y;
        if (playerY > mostrarNiebla)
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
        Color color = new(1, 1, 1, 0);
        while (color.a < .3f)
        {
            color.a += 0.05f;
            m_SpriteRenderer.color = color;

            yield return new WaitForSeconds(1f);
        }
    }
}
