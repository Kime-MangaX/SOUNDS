using UnityEngine;
using System;

public class Sanidad : MonoBehaviour
{
    public Karma karma;


    public int Karma = 0;
    public int sanityPlayer = 30;



    public int sanityMax = 60;
    public int sanityMin = 0;

    public static Action<int, int> OnStatsChange;


    private void OnEnable()
    {
        OnStatsChange += SetStats;
    }
    void Start()
    {
        
    }
    public void SetStats(int sanity,int karma)
    {
        sanityPlayer += sanity;
        Karma += karma;
    }

    public void ReduxSanity (int cantidad)
    {
        sanityPlayer -= cantidad;
        sanityPlayer = Mathf.Clamp(sanityPlayer, sanityMin, sanityMax);
        Debug.Log("La sanida disminuye, Sanidad actual: " + sanityPlayer);
        VerificarEstadoDeSanity();
    }

    public void AumentSanity (int cantidad)
    {
        sanityPlayer += cantidad;
        sanityPlayer = Mathf.Clamp(sanityPlayer, sanityMin, sanityMax);
        Debug.Log("La sanidad aumenta, Sanidad actual: " + sanityPlayer);
        VerificarEstadoDeSanity();

    }

    void VerificarEstadoDeSanity ()
    {
        if (sanityPlayer == 0)
        {
           GameOver();
        }

        else if (sanityPlayer <= 10)
        {
            AlucinFuerte();
        }

        else if (sanityPlayer <= 25)
        {
            AlucinLeve();
        }

        else if (sanityPlayer <= 40)
        {
            CantidaNeutra();
        }

        else
        {
            CantidadBuena();
        }
    }

    void CantidadBuena()
    {
        Debug.Log("Sanidad buena (41 a 60): Todo bien");
    }

    void CantidaNeutra()
    {
        Debug.Log("Sanidad neutra (26 a 40): Todo normal");
    }
    
    void AlucinLeve()
    {
        Debug.Log("Sandia mala (11 a 25): Todo más o menos");
    }

    void AlucinFuerte()
    {
        Debug.Log("Sanidad critica (1 a 10): Todo mal");
    }

    void GameOver()
    {
        Debug.Log("GAME OVER: Saniadad en 0 XD");
    }
   
}
