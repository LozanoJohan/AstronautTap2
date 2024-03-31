using UnityEngine;
using static AudioManager;

public class Star : MonoBehaviour
{
    public GameObject spiral;
    public SpriteRenderer spriteSpiral;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = Tags.STAR;

        spiral = GameObject.Find("Espiral");
        spriteSpiral = spiral.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerUpsManager.I.MagnetPower.IsActivated)
        {
            ShowSpyral();

            float distanceToPlayer = Vector2.Distance(transform.position, Player.I.gameObject.transform.position);

            if (distanceToPlayer < 3) MoveToPlayer();
        }
        else
        {
            UnshowSpyral();
        }
    }

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.gameObject == TouchS.I.gameObject || collided.gameObject.CompareTag("PowerUp")) return;
        else if (collided.gameObject.CompareTag("Player"))
        {
            ScoreManager.I.IncreaseStarsScore(1);

            AudioManager.I.PlaySFX(AudioClips.GAB_COIN);
        }
        gameObject.SetActive(false);
    }

    void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.I.gameObject.transform.position, 5 * Time.deltaTime);
    }

    void ShowSpyral()
    {
        spriteSpiral.color = Color.Lerp(spriteSpiral.color, new Color(1, 0, 1, .4f), Time.deltaTime);
    }

    void UnshowSpyral()
    {
        spriteSpiral.color = Color.Lerp(spriteSpiral.color, new Color(1, 0, 1, 0), Time.deltaTime);
    }

    // Método para cuando agarramos una estrella
    public static void PickStar(GameObject star)
    {
        AudioManager.I.PlaySFX(AudioClips.GAB_COIN);

        // Aquí iría algún tipo de animación si la hacemos ekisde
        Destroy(star);

        int starValue = GetStarValue(star);
        ScoreManager.I.IncreaseStarsScore(starValue);

        UIManager.I.ShowScoreImage(starValue, star.transform.position);
    }

    public static int GetStarValue(GameObject star)
    {
        int starMultiplier = ScoreManager.I.GetStarMultiplier();
        // Por el momento todas las estrellas tienen el mismo valor de puntuación, pero podría cambiarlo en el futuro.
        int starValue = 1;

        return starValue * starMultiplier;
    }
}
