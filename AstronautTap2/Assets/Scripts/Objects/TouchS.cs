using System.Collections;
using UnityEngine;
using static AudioManager;
using static PowerUpsHelper;
public class TouchS : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public GameObject touchedObj;
    private Touch touch;
    public static TouchS I;
    [SerializeField] Camera camara;
    void Awake()
    {
        if (I == null) I = this;
        else Destroy(this);
    }
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Transforma la posicion de toque en coordenadas del juego y deja al gameObject allí
                transform.position = (Vector2)camara.ScreenToWorldPoint(touch.position);
                StartCoroutine(Validation());
            }
        }

        if (Anchor.I.HasReachedTarget())
        {
            if (touchedObj.CompareTag(Tags.STAR))
                Star.PickStar(touchedObj);

            else if (touchedObj.CompareTag(Tags.POWER_UP))
                PowerUpsManager.I.ActivatePowerUpByObject(touchedObj);
            // Si hemos tocado algo diferente como un asteroide, planeta, etc, evita que se desancle y resetee el toque
            else return;

            Anchor.I.Unanchor();
            ResetTouch();
        }
    }

    void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.gameObject.CompareTag(Tags.PLAYER)) return;
        else touchedObj = collided.gameObject;

        // Si el objeto no es una estrella ni un power up se detiene el jugador.
        // Si el objeto es una estrella o un power up deja que el jugador se siga moviendo.
        if (!touchedObj.CompareTag(Tags.STAR) && !touchedObj.CompareTag(Tags.POWER_UP))
            Player.I.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void OnTriggerStay2D(Collider2D collided)
    {
        // El objeto ha sido destruido
        if (touchedObj == null)
        {
            Anchor.I.Unanchor();
            ResetTouch();
        }
        // El objeto ha sido tocado por el jugador y sigue en pie
        else
        {
            transform.parent = collided.gameObject.transform;
            rigidBody2D.velocity = touchedObj.GetComponent<Rigidbody2D>().velocity;

            Anchor.I.AnchorTo(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D collided)
    {
        Anchor.I.Unanchor();
        ResetTouch();
    }

    public void ResetTouch()
    {
        transform.parent = Player.I.gameObject.transform;
        transform.position = Player.I.gameObject.transform.position;
        rigidBody2D.velocity = Player.I.gameObject.GetComponent<Rigidbody2D>().velocity;

        touchedObj = null;
    }

    IEnumerator Validation()
    {
        yield return new WaitForSeconds(0.1f);
        if (touchedObj == null)
        {
            ResetTouch();
        }
    }
}