using System;
using UnityEngine;

public class PausarPlay : MonoBehaviour
{
    public GameObject menuPausa;
    public bool juegopausado = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegopausado)
            {
                Reanudar();
            }
        }

        else
        {
            Pausar();
        }
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegopausado = true;
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegopausado = false;
    }
}
