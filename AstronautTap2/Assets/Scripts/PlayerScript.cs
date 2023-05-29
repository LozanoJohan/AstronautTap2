using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Camera camara;
    public GameObject touchObj;
    public GameObject ancla;
    private Touch touch;
    private Rigidbody2D rigidBody2D;
    private AudioSource audioSource;
    public Sprite[] skins;
    public AudioClip choque;
    private Vector3 direction;
    private Collider2D colider;

    public bool personaje1;
    private float multipier = 1;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("PersonajeSelecctionado", 4);
        GetComponent<SpriteRenderer>().sprite = skins[PlayerPrefs.GetInt("PersonajeSelecctionado", 0)];
        if (PlayerPrefs.GetInt("PersonajeSelecctionado", 0) == 0 || PlayerPrefs.GetInt("PersonajeSelecctionado", 0) == 1)
            personaje1 = true;
        
        if (personaje1) multipier = (100f - PlayerPrefs.GetInt("Poder1", 50))/100f;
    }

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        colider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchObj.transform.position = (Vector2)camara.ScreenToWorldPoint(touch.position);
                StartCoroutine(Validation());
            }
        } 
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        direction = collided.gameObject.transform.position - transform.position;
        if (collided.gameObject.tag == "Meteoro")   rigidBody2D.velocity = -direction * 3 * multipier/ direction.magnitude;
        else rigidBody2D.velocity = -direction * multipier/ direction.magnitude;

        touchObj.transform.parent = transform;
        touchObj.SetActive(false);
        ancla.SetActive(false);

        audioSource.PlayOneShot(choque);
    }

    IEnumerator Validation()
    {
        touchObj.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        if (TouchScript.touchedObj == null) 
        {
            touchObj.SetActive(false);
            StaticStuff.ancla.SetActive(false);
        }
    }
}
