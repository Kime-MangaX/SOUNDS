using UnityEngine;
using Unity.Collections;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Salir()
    {
        Debug.Log("Saliendo del Juego...");
        Application.Quit();
    }
}
