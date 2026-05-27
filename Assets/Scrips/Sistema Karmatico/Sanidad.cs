using UnityEngine;

public class Sanidad : MonoBehaviour
{
    public Karma karma;

    public int sanityPlayer = 30;
    public int sanityMax = 60;
    public int sanityMin = 0;


    void Start()
    {
        
    }

    public void ReduxSanity (int cantidad)
    {
        sanityPlayer -= cantidad;
        sanityPlayer = Mathf.Clamp(sanityPlayer, sanityMin, sanityMax);
        Debug.Log("La sanida disminuye, Sanidad actual: " + sanityPlayer);

    }

    public void AumentSanity (int cantidad)
    {
        sanityPlayer += cantidad;
        sanityPlayer = Mathf.Clamp(sanityPlayer, sanityMin, sanityMax);
        Debug.Log("La sanidad aumenta, Sanidad actual: " + sanityPlayer);

    }
   
}
