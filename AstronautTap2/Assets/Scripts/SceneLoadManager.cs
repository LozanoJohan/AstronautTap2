using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private string nombre;

    public void PasarEscena()
    {
        SceneManager.LoadScene(nombre); 
    }

    public void Skins()
    {
        SceneManager.LoadScene("skins"); 
    }
}
