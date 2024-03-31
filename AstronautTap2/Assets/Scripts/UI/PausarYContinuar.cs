using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarYContinuar : MonoBehaviour
{
    public GameObject panel;
    public GameObject continuar;
    public GameObject pausar;
    public GameObject gameOver;
    public GameObject revive;

    // Update is called once per frame
    public void Pausar()
    {
        Time.timeScale = 0f;

        panel.SetActive(true);
        continuar.SetActive(true);
        pausar.SetActive(false);
    }

    public void Continuar()
    {
        Time.timeScale = 1f;

        panel.SetActive(false);
        continuar.SetActive(false);
        pausar.SetActive(true);
    }

    public void ShowGameOver()
    {
        revive.SetActive(false);
        gameOver.GetComponent<Animator>().SetTrigger("Died");
    }
}
