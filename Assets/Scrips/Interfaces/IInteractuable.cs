using UnityEngine;

public interface IInteractuable
{
    void Interactuar();
    bool PuedeInteractuar { get; }
}