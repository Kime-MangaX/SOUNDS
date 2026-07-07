using UnityEngine;

public interface IStats
{
    int Karma { get; }
    int Sanidad { get; }
    void ModificarStats(int karma, int sanidad);
}