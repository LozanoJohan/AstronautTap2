using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamScript : MonoBehaviour
{
    private Vector2 distanceToPlayer;
    private GameObject objSpawneado;
    private GameObject objAspawnear;
    private int spawnInicial = 0;
    private bool gameStarted;
    private float voltear;
    public Transform player;
    public bool volteable;
    public bool testMode;
    public GameObject meteorito;
    public GameObject[] startObjs;
    public SpriteRenderer panel;
    
    [SerializeField] GameObject[] posibilidades;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = 0;
        position.z = -10;
        transform.position = position;
    }

    void FixedUpdate()
    {
        if (player.gameObject.activeSelf)
        {
            if (Input.touchCount == 1)
            {
                gameStarted = true;
            } 
            if (gameStarted)
            {
                foreach (GameObject obj in startObjs)
                {
                    obj.SetActive(false);    
                }
                
                transform.Translate((Vector2.up * Time.deltaTime * transform.position.y / 200f) + Vector2.up / 1000f);
            }
            if (player.position.y + 2 - transform.position.y > 0)
            {
                distanceToPlayer = player.position - transform.position;
                transform.position = Vector2.MoveTowards(transform.position, 
                        (Vector2)player.position + 2 * Vector2.up, distanceToPlayer.magnitude * Time.deltaTime * 2f);
            }
            
        }
        if (player != null && player.position.y >= spawnInicial && !testMode)
        {
            voltear = Mathf.Round(Random.Range(0f, 1f));
            int indice = Mathf.RoundToInt(Random.Range(0f, posibilidades.Length - 1)); 

            objAspawnear = posibilidades[indice];
            objSpawneado = Instantiate(objAspawnear, new Vector3(0, spawnInicial + 15, 0), Quaternion.identity);

            if (voltear == 1f && volteable && indice != 6) objSpawneado.transform.localScale = new Vector3(
                        -objSpawneado.transform.localScale.x, objSpawneado.transform.localScale.y, 0);
            
            if (spawnInicial % 60 == 0 && transform.position.y != 0) 
                StartCoroutine(SpawnMeteoros());
                
            spawnInicial += 20;
        }
    }

    IEnumerator SpawnMeteoros()
    {
        for (int i = 0; i < 10; i++)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + 0.015f);
            StaticStuff.audioSource.volume -= 0.007f;
            Instantiate(meteorito, new Vector2(-4, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(.25f);

            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + 0.015f);
            StaticStuff.audioSource.volume -= 0.007f;
            Instantiate(meteorito, new Vector2(4, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(.25f);

            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + 0.015f);
            StaticStuff.audioSource.volume -= 0.007f;
            Instantiate(meteorito, new Vector2(4, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(.25f);

            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + 0.015f);
            StaticStuff.audioSource.volume -= 0.007f;
            Instantiate(meteorito, new Vector2(-4, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(.25f);
        }
        for (int i = 0; i < 10; i++)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - 0.015f);
            StaticStuff.audioSource.volume += 0.007f;
            yield return new WaitForSeconds(.25f);

            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - 0.015f);
            StaticStuff.audioSource.volume += 0.007f;
            yield return new WaitForSeconds(.25f);

            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - 0.015f);
            StaticStuff.audioSource.volume += 0.007f;
            yield return new WaitForSeconds(.25f);

            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - 0.015f);
            StaticStuff.audioSource.volume += 0.007f;
            yield return new WaitForSeconds(.25f);
        }
    }
}
