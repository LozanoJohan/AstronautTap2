using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolScript : MonoBehaviour
{
    public static bool invencible = false;
    public static float startTime;
    private Rainbow rainbow;
    private AudioSource audioSource;
    public AudioClip quemado;
    public static int powerDuration;
    // Start is called before the first frame update
    void Start()
    {
        rainbow = StaticStuff.player.GetComponent<Rainbow>();
        powerDuration = 4 + PlayerPrefs.GetInt("invincibilityupg", 0);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invencible)
        {
            rainbow.enabled = true;
            if (startTime + powerDuration < Time.time)
            {
                invencible = false;
                rainbow.enabled = false;
                StaticStuff.player.GetComponent<SpriteRenderer>().color = Color.white;

                StaticStuff.notActive = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        if (collided.gameObject.name == "TouchObj") return;

        if (collided.gameObject.tag == "Untagged" && 
                StaticStuff.touchObj.transform.IsChildOf(collided.gameObject.transform))
        {
            StaticStuff.touchObj.transform.parent = StaticStuff.player.transform;
            StaticStuff.touchObj.SetActive(false);
            StaticStuff.ancla.SetActive(false);
        }

        if (collided.gameObject.tag == "Player")
        {
            if (!invencible)
            {
                collided.gameObject.SetActive(false);
                StaticStuff.GameOver();
            }
            else return;
        }
        collided.gameObject.SetActive(false);
        if (quemado) audioSource.PlayOneShot(quemado);
    }
}
