using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject[] character;

    public void RightArrow()
    {
        int i = GetCurrentCharacter();

        character[i].SetActive(false);
        character[(i+1) % character.Length].SetActive(true);
    } 

    public void LeftArrow()
    {
        int i = GetCurrentCharacter();

        character[i].SetActive(false);
        character[Mathf.Abs((i-1) % character.Length)].SetActive(true);
    }

    public int GetCurrentCharacter()
    {
        for (int i = 0; i < character.Length; i++)
        {
            if (character[i].activeSelf) return i;
        }
        return 0;
    }
}
