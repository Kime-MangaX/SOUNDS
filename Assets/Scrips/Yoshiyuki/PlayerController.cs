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
    private float moveX;
    private float velocidadActual;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        rb.rotation = 0f;

        // Leer input
        moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidad;

        // Voltear sprite
        if (moveX != 0)
            transform.localScale = new Vector3(moveX > 0 ? 1 : -1, 1, 1);

        Saltar();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveX * velocidadActual, rb.linearVelocity.y);
    }

    void Saltar()
    {
        estaEnSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

        if (estaEnSuelo)
            puedeDoubleSalto = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (estaEnSuelo)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            }
            else if (puedeDoubleSalto)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
                puedeDoubleSalto = false;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (puntoSuelo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(puntoSuelo.position, radioSuelo);
        }
    }
}