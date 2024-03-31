using UnityEngine;
using static PowerUpsHelper;

[CreateAssetMenu(fileName = "PowerUp", menuName = "Game/PowerUp")]
public class PowerUpSO : ScriptableObject
{
    public PowerUpType powerUpType;
    public int initialPowerDuration = 4;
    public int PowerDuration;
    [HideInInspector]
    public bool IsActivated { get; set; } = false;
    [HideInInspector]
    public float StartTime { get; set; } = 0;
    public void Activate()
    {
        StartTime = Time.time;
        IsActivated = true;
    }

    void OnEnable()
    {
        PowerDuration = initialPowerDuration + PlayerPrefs.GetInt(GetPowerUpName(powerUpType), 0);
    }
}
