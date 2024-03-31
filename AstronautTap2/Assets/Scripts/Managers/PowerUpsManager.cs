using UnityEngine;
using static CharactersManager;
using static PowerUpsHelper;

public class PowerUpsManager : MonoBehaviour
{
    public static PowerUpsManager I;

    public PowerUpSO MagnetPower;
    public PowerUpSO GoldPower;
    public PowerUpSO X2Power;
    public PowerUpSO InvincibilityPower;

    private CharacterSO character;

    void Awake()
    {
        if (I == null) I = this;
        else Destroy(this);
    }

    void Start()
    {
        character = GetCurrentCharacter();
    }

    void Update()
    {
        CheckAndDeactivatePowerUp(X2Power);
        CheckAndDeactivatePowerUp(MagnetPower);
        CheckAndDeactivatePowerUp(GoldPower);
        CheckAndDeactivatePowerUp(InvincibilityPower);

        CharacterSO SUS = Characters.SUS;

        character = GetCurrentCharacter();

        if (character == SUS && ScoreManager.I.stars % SUS.GetPowerValue() == 0)
        {
            InvincibilityPower.Activate();
        }
    }
    public void CheckAndDeactivatePowerUp(PowerUpSO powerUp)
    {
        if (Time.time - powerUp.StartTime > powerUp.PowerDuration)
        {
            powerUp.IsActivated = false;
        }
    }
    // Método revisado para activar los poderes en función del tipo actualmente configurado.
    public void ActivatePowerUpByType(PowerUpType currentPowerUpType)
    {
        switch (currentPowerUpType)
        {
            case PowerUpType.MAGNET:
                MagnetPower.Activate();
                break;
            case PowerUpType.INVINCIBILITY:
                InvincibilityPower.Activate();
                break;
            case PowerUpType.DOUBLE_SCORE:
                X2Power.Activate();
                break;
            case PowerUpType.GOLD:
                GoldPower.Activate();
                break;
        }
    }

    // Método estático para activar el powerup de un objeto
    public void ActivatePowerUpByObject(GameObject gameObject)
    {
        PowerUp pu = gameObject.GetComponent<PowerUp>();
        PowerUpType puType = pu.powerUpType;
        ActivatePowerUpByType(puType);

        // Aquí iría algún tipo de animación si la hacemos ekisde
        Destroy(gameObject);
    }
}
