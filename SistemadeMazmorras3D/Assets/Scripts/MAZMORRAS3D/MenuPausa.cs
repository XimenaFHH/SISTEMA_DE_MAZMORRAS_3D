using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botónPause;
    [SerializeField] private GameObject menúPause;

    private bool juegopausado = false;

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegopausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        juegopausado = true;
        Time.timeScale = 0f;
        botónPause.SetActive(false);
        menúPause.SetActive(true);
    }

    public void Reanudar()
    {
        juegopausado = true;
        Time.timeScale = 1f;
        botónPause.SetActive(true);
        menúPause.SetActive(false);
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando Juego.");
        Application.Quit();
    }



}
