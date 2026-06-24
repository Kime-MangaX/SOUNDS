using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float velocidadCorrer = 9f;

    [Header("Salto")]
    public float fuerzaSalto = 12f;
    public Transform puntoSuelo;
    public float radioSuelo = 0.2f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private bool estaEnSuelo;
    private bool puedeDoubleSalto;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.freezeRotation = true;
    }

    void Update()
    {
        rb.rotation = 0f;

        Mover();
        Saltar();
    }

    void Mover()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        // Shift para correr
        float velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidad;

        rb.linearVelocity = new Vector2(moveX * velocidadActual, rb.linearVelocity.y);

        // Voltear sprite según dirección
        if (moveX != 0)
            transform.localScale = new Vector3(moveX > 0 ? 1 : -1, 1, 1);
    }

    void Saltar()
    {
        // Detectar si está en el suelo
        estaEnSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

        if (estaEnSuelo)
            puedeDoubleSalto = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (estaEnSuelo)
            {
                // Salto normal
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            }
            else if (puedeDoubleSalto)
            {
                // Doble salto
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
                puedeDoubleSalto = false;
            }
        }
    }

    // Visualizar el punto de suelo en el editor
    void OnDrawGizmosSelected()
    {
        if (puntoSuelo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(puntoSuelo.position, radioSuelo);
        }
    }
}