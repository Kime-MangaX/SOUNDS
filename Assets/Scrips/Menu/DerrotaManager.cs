using UnityEngine;
using UnityEngine.SceneManagement;

public class DerrotaManager : MonoBehaviour
{
    public void Reintentar()
    {
        SceneManager.LoadScene("Mapa1_Tutorial");
    }

    public void IrAlMenu()
    {
        SceneManager.LoadScene("TileScream");
    }
}