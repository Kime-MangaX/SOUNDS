using UnityEngine;
using UnityEngine.SceneManagement;

public class DerrotaManager : MonoBehaviour
{
    // Llama estos métodos desde los botones de la UI de derrota
    public void Reintentar()
    {
        SceneManager.LoadScene("Mapa1_Tutorial");
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}