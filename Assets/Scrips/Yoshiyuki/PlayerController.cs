using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entidad
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool estaEnSuelo;
    private bool puedeDoubleSalto;
    private bool estaDashing = false;
    private bool puedeDash = true;
    private float moveX;
    private float velocidadActual;

    [Header("Movimiento")]
    public float velocidad = 5f;
    public float velocidadCorrer = 9f;

    [Header("Salto")]
    public float fuerzaSalto = 12f;
    public Transform puntoSuelo;
    public float radioSuelo = 0.2f;
    public LayerMask capaSuelo;

    [Header("Dash")]
    public float fuerzaDash = 15f;
    public float duracionDash = 0.2f;
    public float cooldownDash = 1f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        rb.rotation = 0f;

        if (estaDashing) return;

        moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidad;

        if (moveX != 0)
            transform.localScale = new Vector3(moveX > 0 ? 1 : -1, 1, 1);

        anim.SetFloat("Movimiento", Mathf.Abs(moveX), 0.1f, Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && puedeDash)
            StartCoroutine(Dash());

        Saltar();
    }

    void FixedUpdate()
    {
        if (!estaDashing)
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
                anim.SetTrigger("Saltar");
            }
            else if (puedeDoubleSalto)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
                anim.SetTrigger("Saltar");
                puedeDoubleSalto = false;
            }
        }
    }

    System.Collections.IEnumerator Dash()
    {
        estaDashing = true;
        puedeDash = false;

        anim.SetTrigger("Dash");

        float direccion = transform.localScale.x;
        rb.linearVelocity = new Vector2(direccion * fuerzaDash, 0f);

        yield return new WaitForSeconds(duracionDash);
        estaDashing = false;

        yield return new WaitForSeconds(cooldownDash);
        puedeDash = true;
    }

    protected override void OnStatsModificados()
    {
        Debug.Log($"Player - Karma: {karma} | Sanidad: {sanidad}");
    }

    protected override void OnMuerte()
    {
        Debug.Log("Player muerto");
        // Aquí después conectamos con escena de Derrota
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