
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Game/Character")]
public class CharacterSO : ScriptableObject
{
    [HideInInspector]
    public int id;
    public string characterName;
    public string power;
    [HideInInspector]
    public Sprite currentSkin;
    [HideInInspector]
    public bool isUnlocked = false;
    public int defaultPowerValue;
    public Skin[] skins;
    private string powerName;
    public int price;

    void OnEnable()
    {
        powerName = "UPGRADE_" + power.ToLower().Replace(" ", "_");
        
        skins[0].isUnlocked = true; // El primer skin es unlocked por defecto.
        currentSkin = skins[0].sprite;
        // Asigna el ID de cada skin a su índice en la lista
        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].id = i;
        }
    }

    public int GetPowerValue()
    {
        return PlayerPrefs.GetInt(powerName, defaultPowerValue);
    }
}

