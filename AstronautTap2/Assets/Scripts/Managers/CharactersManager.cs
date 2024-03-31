using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class CharactersManager : MonoBehaviour
{
    public static class Characters
    {
        // Lista que contendrá los personajes
        public static List<CharacterSO> characters = new();
        public static CharacterSO ASTRONAUT;
        public static CharacterSO ENRRIQUE;
        public static CharacterSO SUS;
    }

    public CharacterSO ASTRONAUT;
    public CharacterSO ENRRIQUE;
    public CharacterSO SUS;
    public Sprite[] skins;
    private static Sprite[] _skins;
    void Awake()
    {
        _skins = skins;
        // El astronauta está desbloqueado por defecto
        ASTRONAUT.isUnlocked = true;

        //Añadir más personajes
        Characters.characters.Add(ASTRONAUT);
        Characters.characters.Add(ENRRIQUE);
        Characters.characters.Add(SUS);

        Characters.ASTRONAUT = ASTRONAUT;
        Characters.ENRRIQUE = ENRRIQUE;
        Characters.SUS = SUS;

        // Asigna el ID de cada personaje a su índice en la lista
        for (int i = 0; i < Characters.characters.Count; i++)
        {
            Characters.characters[i].id = i;
        }
    }

    public static CharacterSO GetCurrentCharacter()
    {
        // Obtiene el ID del personaje seleccionado
        int selectedCharacter = PlayerPrefs.GetInt("PersonajeSeleccionado", 0);

        // Calcula el personaje basado en el ID seleccionado
        // Esto asume que cada dos IDs consecutivos corresponden al mismo personaje con poderes
        return Characters.characters[selectedCharacter / 2];
    }

    public static void SetCharacter(CharacterSO character)
    {
        // Guarda el ID del personaje seleccionado
        PlayerPrefs.SetInt("PersonajeSeleccionado", character.id);
    }

    public static Sprite GetCurrentSkin()
    {
        CharacterSO currentCharacter = GetCurrentCharacter();

        return currentCharacter.currentSkin;
    }

    public static bool IsDoubleEnrique()
    {
        CharacterSO character = GetCurrentCharacter();
        CharacterSO ENRRIQUE = Characters.ENRRIQUE;

        return character == ENRRIQUE && Random.Range(0, 100) <= ENRRIQUE.GetPowerValue();
    }
}
