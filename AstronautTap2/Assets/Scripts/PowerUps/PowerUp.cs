using UnityEngine;
using static PowerUpsHelper;

class PowerUp : MonoBehaviour
{
    public bool setIndex;
    public int index;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    // Agregado para llevar el registro del tipo de power-up actual.
    [HideInInspector]
    public PowerUpType powerUpType;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!setIndex) index = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[index];
        powerUpType = (PowerUpType)index; // Guardar el tipo actual para uso futuro.

        // Solo configurar, no activar.
        ConfigurePowerUp(powerUpType);
    }

    // Este método ahora solo hace configuraciones visuales o de componentes, sin activar la lógica del power-up.
    private void ConfigurePowerUp(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.INVINCIBILITY:
                EnableBehavior<Rainbow>();
                break;
            case PowerUpType.DOUBLE_SCORE:
                EnableBehavior<Rainbow>();
                EnableBehavior<Rotation>();
                break;
            case PowerUpType.GOLD:
                spriteRenderer.color = new Color(1f, 0.4f, 0f);
                break;
        }
    }

    private void EnableBehavior<T>() where T : MonoBehaviour
    {
        if (TryGetComponent<T>(out T obj)) obj.enabled = true;
    }
}
