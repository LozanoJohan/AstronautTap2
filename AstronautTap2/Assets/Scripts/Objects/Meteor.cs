using UnityEngine;

public class Meteor : PushingObject
{
    public override float PullbackMultiplier => 2f;
    public Vector2 speed;
    private int randomDegrees;
    private readonly int minRotationDegrees = -60;
    private readonly int maxRotationDegrees = 80;
    public float pushForce = 2f;

    void Awake()
    {
        randomDegrees = Random.Range(minRotationDegrees, maxRotationDegrees);
    }

    void Start()
    {
        gameObject.tag = Tags.METEOR;

        transform.rotation = Quaternion.Euler(0, 0, randomDegrees);

        bool isAtRight = transform.position.x == 4;
        if (isAtRight) transform.localScale = Vector3.left;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.localScale.x == -1) transform.Translate(-speed);
        else transform.Translate(speed);
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        GameObject player = collided.gameObject;
        Rigidbody2D playerVelocity = player.GetComponent<Rigidbody2D>();

        // Pushes user
        Vector3 direction = player.transform.position - transform.position;
        playerVelocity.velocity = -direction * pushForce / direction.magnitude;

        Anchor.I.Unanchor();
    }
}
