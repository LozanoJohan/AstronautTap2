using static ObstacleGroupSO;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleManager : MonoBehaviour
{
    public SpriteRenderer panel;
    [SerializeField] ObstacleGroupSO[] posibleObstacles;
    private int spawnInicial = 0;
    public bool testMode;
    public GameObject meteorito;
    private Transform playerTrs;
    public float difficultyRange = 60;
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
        Difficulty difficulty = GetDifficultyLevel(y);
        ObstacleGroupSO[] filteredObtacles = FilterObstaclesByDifficulty(difficulty);

        bool flip = Mathf.Round(Random.Range(0f, 1f)) == 1f;
        int i = Mathf.RoundToInt(Random.Range(0f, filteredObtacles.Length - 1));

        ObstacleGroupSO obstacleGroup = filteredObtacles[i];
        GameObject obstacles = obstacleGroup.obstacles;
        
        GameObject spawnedGameObject = Instantiate(obstacles, 
                                            new Vector3(0, y + obstacleGroup.height, 0), 
                                            Quaternion.identity);

        if (flip && obstacleGroup.isFlippable)
        {
            FlipHorizontally(spawnedGameObject);
        }

        spawnInicial += 20;
    }

    private Difficulty GetDifficultyLevel(float y)
    {
        int difficulty = Mathf.Clamp(Mathf.RoundToInt(y / difficultyRange),
                            min: (int)Difficulty.Easy,
                            max: (int)Difficulty.Hard);

        return (Difficulty) difficulty;
    }

    private ObstacleGroupSO[] FilterObstaclesByDifficulty(Difficulty difficulty)
    {
        return posibleObstacles.Where(obstacle => obstacle.difficulty == difficulty).ToArray();
    }
    private void FlipHorizontally(GameObject obstacle)
    {
        Vector3 scale = obstacle.transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
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
