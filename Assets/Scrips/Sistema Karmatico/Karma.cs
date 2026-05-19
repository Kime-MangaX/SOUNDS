using UnityEngine;

public class Karma : MonoBehaviour
{
    public int accionesBuenas = 2;
    public int accionesNeutras = 1;
    public int accionesMalas = 2;

    public int karmaPlayer = 20;
    public int karmaMax = 20;
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
        karmaPlayer += accionesMalas;
        karmaPlayer = Mathf.Clamp(karmaPlayer, karmaMin, karmaMax);
        Debug.Log("Accion mala, karma actual: " + karmaPlayer);
    }


    void Update()
    {
        
    }
}
