using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject[] personajes;

    public void RightArrow()
    {
        int i = GetCurrentPersonaje();

        personajes[i].SetActive(false);
        personajes[(i+1) % personajes.Length].SetActive(true);
    } 

    public void LeftArrow()
    {
        int i = GetCurrentPersonaje();

        personajes[i].SetActive(false);
        personajes[Mathf.Abs((i-1) % personajes.Length)].SetActive(true);
    }

    public int GetCurrentPersonaje()
    {
        for (int i = 0; i < personajes.Length; i++)
        {
            if (personajes[i].activeSelf) return i;
        }
        return 0;
    }
}
