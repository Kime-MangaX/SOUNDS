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
            TestPause();
        }

    }

    public void TestPause()
    {
       if( juegopausado)
        {
            Reanudar();
        }
       else
        {
            Pausar();
        }
    }


    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegopausado = false;
        Debug.Log("Esto debe regresar por favor ahhhhhhhhhhhhhhhh...");
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegopausado = true;
        Debug.Log("Esto debe Pausar Todo");
    }


}
