using UnityEngine;
using static CharactersManager;
using static AudioManager;

public class ScoreManager : MonoBehaviour
{
    public int height;
    public int stars = 0;
    private float heightWeight = 1f;
    private float starsWeight = 2f;
    public static ScoreManager I;

    void Awake()
    {
        if (I == null) I = this;
        else Destroy(this);
    }
    void Update()
    {
        height = (int)Player.I.gameObject.transform.position.y;
        int fixedHeight = height < 0 ? 0 : height;

        UIManager.I.SetHeightText(fixedHeight);
    }
    public void IncreaseStarsScore(int starsScoreToIncrease)
    {
        stars += starsScoreToIncrease;
        UIManager.I.SetStarsCountText(stars);
    }

    public int GetStarMultiplier()
    {
        int scoreMultiplier = 1;
        if (IsDoubleEnrique())
            scoreMultiplier *= 2;
        if (PowerUpsManager.I.X2Power.IsActivated)
            scoreMultiplier *= 2;

        return scoreMultiplier;
    }
    
    public int GetFinalScore()
    {
        return Mathf.FloorToInt(height * heightWeight + stars * starsWeight);
    }

}
