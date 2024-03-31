using System.Collections;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public SpriteRenderer panel;
    [SerializeField] GameObject[] posibleObstacles;
    private int spawnInicial = 0;
    public bool testMode;
    public bool isFlippable;
    private bool isFlipped;
    private GameObject objSpawneado;
    public GameObject meteorito;
    private GameObject objAspawnear;
    private Transform playerTrs;
    void Start()
    {
        playerTrs = Player.I.gameObject.transform;
    }
    void FixedUpdate()
    {
        if (GameManager.I.gameStarted)
        {
            if (playerTrs != null && playerTrs.position.y >= spawnInicial && !testMode)
            {
                SpawnObstacles(y: spawnInicial);
                if (spawnInicial % 60 == 0 && playerTrs.position.y != 0)
                    StartMeteorShower();
            }
        }
    }
    public void SpawnObstacles(float y)
    {
        isFlipped = Mathf.Round(Random.Range(0f, 1f)) == 1f;
        int indice = Mathf.RoundToInt(Random.Range(0f, posibleObstacles.Length - 1));

        objAspawnear = posibleObstacles[indice];
        objSpawneado = Instantiate(objAspawnear, new Vector3(0, y + 15, 0), Quaternion.identity);

        if (isFlipped && isFlippable && indice != 6) objSpawneado.transform.localScale = new Vector3(
                    -objSpawneado.transform.localScale.x, objSpawneado.transform.localScale.y, 0);

        spawnInicial += 20;
    }
    public IEnumerator SpawnMeteoros()
    {
        for (int i = 0; i < 10; i++)
        {
            IncreaseVolume(-0.007f, 0.015f);
            Instantiate(meteorito, new Vector2(-4, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(.25f);

            IncreaseVolume(-0.007f, 0.015f);
            Instantiate(meteorito, new Vector2(4, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(.25f);

            IncreaseVolume(-0.007f, 0.015f);
            Instantiate(meteorito, new Vector2(4, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(.25f);

            IncreaseVolume(-0.007f, 0.015f);
            Instantiate(meteorito, new Vector2(-4, transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(.25f);
        }
        for (int i = 0; i < 10; i++)
        {
            IncreaseVolume(0.007f, -0.015f);
            yield return new WaitForSeconds(.25f);

            IncreaseVolume(0.007f, -0.015f);
            yield return new WaitForSeconds(.25f);

            IncreaseVolume(0.007f, -0.015f);
            yield return new WaitForSeconds(.25f);

            IncreaseVolume(0.007f, -0.015f);
            yield return new WaitForSeconds(.25f);
        }
    }

    void IncreaseVolume(float vol, float alpha)
    {
        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + alpha);
        AudioManager.I.IncreaseMusicVolume(vol);
    }

    public void StartMeteorShower()
    {
        StartCoroutine(SpawnMeteoros());
    }

}
