using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeShop : MonoBehaviour
{
    public Button characters;
    public Button upgrades;
    public GameObject charactersGO;
    public GameObject upgradesGO;

    public void FromCharactersToUpgrades()
    {
        upgrades.interactable = false;
        characters.interactable = true;

        upgradesGO.SetActive(true);
        charactersGO.SetActive(false);
    }

    public void FromUpgradesToCharacters()
    {
        upgrades.interactable = true;
        characters.interactable = false;

        upgradesGO.SetActive(false);
        charactersGO.SetActive(true);
    }
}
