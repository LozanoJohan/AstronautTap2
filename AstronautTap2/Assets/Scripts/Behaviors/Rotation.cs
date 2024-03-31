using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] bool setSpeed;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (!setSpeed)
            speed = Random.Range(-3f, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, speed);
    }
}
