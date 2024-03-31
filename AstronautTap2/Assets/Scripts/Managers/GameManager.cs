using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public float startTime;
    [HideInInspector]
    public float timeDied;
    [HideInInspector]
    public bool gameStarted = false;
    public static GameManager I;
    public GameObject initialGameObjects;
    void Awake()
    {
        if (I == null) I = this;
        else Destroy(this);
    }
    // Update is called once per frame
    public void StartGame()
    {
        UIManager.I.ShowGameCanvas();
        gameStarted = true;
        initialGameObjects.SetActive(true);
    }

    public void GameOver()
    {
        timeDied = Time.time;
        int finalScore = ScoreManager.I.GetFinalScore();
        // Desactivar jugador
        if (Player.I.gameObject) Player.I.gameObject.SetActive(false);

        UIManager.I.ShowGameOver();
        UIManager.I.UpdateTotalStarsCountText();

        // Este es el slider para poder revivir, cuando llegue a 0 no podrá hacerlo
        UIManager.I.ShowReviveSlider(timeDied);

        PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars", 0) + ScoreManager.I.stars);

        // AudioManager.I.PlaySound("GameOver"); 
        AudioManager.I.MuteMusic();

        if (finalScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            UIManager.I.UpdateHighScoreText();
            UIManager.I.ShowHighScore();

            PlayerPrefs.SetInt("HighScore", finalScore);
        }
    }
}
