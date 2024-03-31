public class CharacterHelper
{
    public static class CharacterNames
    {
        public const string ASTRONAUT = "Astronaut";
        public const string ENRRIQUE = "Enrique";
        public const string SUS = "Sus";
    }

    public enum CharacterType { ASTRONAUT, ENRRIQUE, SUS }

    public static string GetCharacterName(CharacterType type)
    {
        return type switch
        {
            CharacterType.ASTRONAUT => CharacterNames.ASTRONAUT,
            CharacterType.ENRRIQUE => CharacterNames.ENRRIQUE,
            CharacterType.SUS => CharacterNames.SUS,
            _ => null,
        };
    }
}