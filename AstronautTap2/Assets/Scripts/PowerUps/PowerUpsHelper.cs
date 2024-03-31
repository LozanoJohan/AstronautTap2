public class PowerUpsHelper
{
    public static class PowerUpNames
    {
        public const string INVINCIBILITY = "POWER_invincivility";
        public const string DOUBLE_SCORE = "POWER_double_score";
        public const string MAGNET = "POWER_magnet";
        public const string GOLD = "POWER_gold";
    }

    public enum PowerUpType { MAGNET, INVINCIBILITY, DOUBLE_SCORE, GOLD }

    public static string GetPowerUpName(PowerUpType type)
    {
        return type switch
        {
            PowerUpType.INVINCIBILITY => PowerUpNames.INVINCIBILITY,
            PowerUpType.DOUBLE_SCORE => PowerUpNames.DOUBLE_SCORE,
            PowerUpType.MAGNET => PowerUpNames.MAGNET,
            PowerUpType.GOLD => PowerUpNames.GOLD,
            _ => null,
        };
    }
}