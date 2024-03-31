using UnityEngine;
using static AudioManager;
using static CharactersManager;

public class Player : MonoBehaviour
{
    public GameObject playerObj;
    public float speed = 5f;
    public GameObject touchObj;
    public GameObject ancla;
    private Rigidbody2D rigidBody2D;
    public AudioClip choque;
    private float pullbackMultiplier = 1;
    public static Player I;

    // Start is called before the first frame update
    void Awake()
    {
        if (I == null) I = this;
        else Destroy(this);

        // PlayerPrefs.SetInt("PersonajeSeleccionado", 4);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = GetCurrentSkin();

        CharacterSO character = GetCurrentCharacter();
        CharacterSO ASTRONAUT = Characters.ASTRONAUT;

        if (character == Characters.ASTRONAUT) pullbackMultiplier = (100f - ASTRONAUT.GetPowerValue()) / 100f;
    }

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Anchor.I.HasReachedTarget() &&
            !TouchS.I.touchedObj.CompareTag(Tags.POWER_UP) &&
            !TouchS.I.touchedObj.CompareTag(Tags.STAR))
        {
            float distance = Vector2.Distance(touchObj.transform.position, transform.position);
            var step = speed * Time.deltaTime * distance;

            // Mover al jugador al objeto touched, con una velocidad multiplicada por la distance entre ellos.
            transform.position = Vector2.MoveTowards(transform.position, touchObj.transform.position,
                    step);
        }
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        GameObject collidedObj = collided.gameObject;

        // Si colisiona con un objeto, aplica el pullback
        if (collidedObj.CompareTag(Tags.METEOR) ||
            collidedObj.CompareTag(Tags.ASTEROID) ||
            collidedObj.CompareTag(Tags.PLANNET))
        {
            Pullback(from: collidedObj);
        }
        else if (collidedObj.CompareTag(Tags.STAR)) Star.PickStar(collidedObj);

        // Restauramos los valores por defecto del ancla y toque
        Anchor.I.Unanchor(); 
        TouchS.I.ResetTouch();
        AudioManager.I.PlaySFX(AudioClips.HIT);
    }

    void Pullback(GameObject from)
    {
        // Se obtiene la dirección de la colisión y se aplica un pullback al jugador en esa dirección.
        Vector2 direction = from.transform.position - transform.position;

        float objPullback = from.GetComponent<PushingObject>().PullbackMultiplier;
        rigidBody2D.velocity = objPullback * pullbackMultiplier * -direction / direction.magnitude;
    }
}
