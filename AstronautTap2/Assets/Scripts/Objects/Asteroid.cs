using System.Collections;
using UnityEngine;

public class Asteroid : PushingObject
{
    public override float PullbackMultiplier => 2f;
    public GameObject lightPrefab;
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    public Sprite damagedAsteroid;
    private bool isGoldAsteroid;
    private int collisionTimes = 0;
    public float speed = 1f;
    private GameObject _light;

    void Start()
    {
        gameObject.tag = Tags.ASTEROID;

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        isGoldAsteroid = IsGoldAsteroid();


        if (isGoldAsteroid)
        {
            spriteRenderer.color = Color.yellow;
            SetGoldAsteroid();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerUpsManager.I.GoldPower.IsActivated)
        {
            SetGoldAsteroid();
        }
        else if (_light && _light.activeSelf)
        {
            spriteRenderer.color = Color.white;
            _light.SetActive(false);
            PowerUpsManager.I.GoldPower.IsActivated = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        if (collided.gameObject == Player.I.gameObject) collisionTimes++;

        switch (collisionTimes)
        {
            case 1:
                spriteRenderer.sprite = damagedAsteroid;
                break;

            case 2:
                // Si el asteroide colisiona con el jugador, se resetea el toque. Si quitamos esto da error
                Transform touchTrs = TouchS.I.gameObject.transform;
                if (touchTrs.IsChildOf(transform)) TouchS.I.ResetTouch();
    
                if (isGoldAsteroid)
                {
                    ScoreManager.I.IncreaseStarsScore(1);
                }
                spriteRenderer.sprite = null;
                // Esperar un poco antes de destruirse para que no se rompa la colision.
                Destroy(gameObject);
                break;
        }
        Pullback(from: collided.gameObject);
    }
    void Pullback(GameObject from)
    {
        Vector3 direction = from.transform.position - transform.position;
        rigidBody2D.velocity = -direction * speed / direction.magnitude;

    }

    bool IsGoldAsteroid()
    {
        // Probabilidad de que sea un asteroide de oro 1/20.
        int probab = Random.Range(0, 20);
        return probab == 1;
    }

    void SetGoldAsteroid()
    {
        spriteRenderer.color = Color.yellow;
        if (transform.childCount == 0)
        {
            _light = Instantiate(lightPrefab, transform.position, Quaternion.identity);
            _light.transform.parent = transform;
        }
    }
}
