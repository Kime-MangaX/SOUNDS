using UnityEngine;

public class Karma : MonoBehaviour
{
    public int accionesBuenas = 3;
    public int accionesNeutras = 2;
    public int accionesMalas = -5;

    public int karmaPlayer = 30;
    public int karmaMax = 60;
    public int karmaMin = 0;




    void Start()
    {

    }

    public void AccionesBuenas()
    {
        karmaPlayer += accionesBuenas;
        karmaPlayer = Mathf.Clamp(karmaPlayer, karmaMin, karmaMax);
        Debug.Log("Accion mala, karma actual: " + karmaPlayer);
    }

    public void AccionesNeutras()
    {
        karmaPlayer += accionesNeutras;
        karmaPlayer = Mathf.Clamp(karmaPlayer, karmaMin, karmaMax);
        Debug.Log("Accion neutra, karma actual: " + karmaPlayer);
    }

    public void AccionesMalas()
    {
        karmaPlayer -= accionesMalas;
        karmaPlayer = Mathf.Clamp(karmaPlayer, karmaMin, karmaMax);
        Debug.Log("Accion mala, karma actual: " + karmaPlayer);
    }

    void Update()
    {

    }
}
