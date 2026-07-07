using UnityEngine;

public interface IDañable
{
    void RecibirDaño(int cantidad);
    bool EstaVivo { get; }
}