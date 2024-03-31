using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public void InstaButton()
    {
        Application.OpenURL("https://www.instagram.com/johanlozano51/");
    }

    public void OnConfigButtonPressed()
    {
        GetComponent<Animator>().SetTrigger("Died");
    }

    public void OnBackButtonPressed()
    {
        GetComponent<Animator>().SetTrigger("Close");
    }
}
