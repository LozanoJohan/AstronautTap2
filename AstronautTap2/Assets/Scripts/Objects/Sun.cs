using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioManager;

public class Sun : MonoBehaviour
{
    private Rainbow rainbow;
    void Start()
    {
        gameObject.tag = Tags.SUN;

        rainbow = Player.I.gameObject.GetComponent<Rainbow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerUpsManager.I.InvincibilityPower.IsActivated)
        {
            rainbow.enabled = true;
        }
        else
        {
            rainbow.enabled = false;
            Player.I.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void OnCollisionEnter2D(Collision2D collided)
    {
        if (collided.gameObject.name == "TouchObj") return;

        GameObject touchObj = TouchS.I.gameObject;
        
        AudioManager.I.PlaySFX(AudioClips.DEATH);

        if (collided.gameObject.CompareTag(Tags.ASTEROID) &&
                touchObj.transform.IsChildOf(collided.gameObject.transform))
        {
            TouchS.I.ResetTouch();
            Anchor.I.Unanchor();
        }

        if (collided.gameObject.CompareTag(Tags.PLAYER))
        {
            if (!PowerUpsManager.I.InvincibilityPower.IsActivated)
            {
                GameManager.I.GameOver();
                return;
            }
            else return;
        }
        collided.gameObject.SetActive(false);
    }
}
