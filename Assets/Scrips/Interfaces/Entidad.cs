using System;
using UnityEngine;

public abstract class Entidad : MonoBehaviour, IStats, IDañable
{
    [Header("Stats Base")]
    [SerializeField] protected int karma = 0;
    [SerializeField] protected int sanidad = 100;

    // ✅ Action 2 - evento de muerte
    public static Action<Entidad> OnEntidadMuerta;

    public int Karma => karma;
    public int Sanidad => sanidad;

    public virtual void ModificarStats(int karmaVal, int sanidadVal)
    {
        karma += karmaVal;
        sanidad += sanidadVal;
        sanidad = Mathf.Clamp(sanidad, 0, 100);
        OnStatsModificados();
    }

    public bool EstaVivo => sanidad > 0;

    public virtual void RecibirDaño(int cantidad)
    {
        ModificarStats(0, -cantidad);
        if (!EstaVivo)
            OnMuerte();
    }

    protected abstract void OnStatsModificados();
    protected abstract void OnMuerte();
}