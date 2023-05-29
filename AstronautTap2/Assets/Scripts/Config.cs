using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
