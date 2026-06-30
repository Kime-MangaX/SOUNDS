using UnityEngine;
using Unity.Collections;
using UnityEngine.SceneManagement;

public class MenuSystem
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Salir()
    {
        Application.Quit();
    }
}
