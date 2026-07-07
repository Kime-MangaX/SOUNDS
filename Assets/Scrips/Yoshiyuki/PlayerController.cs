using System;
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
    private float timerDaño = 0f;
    private bool estaEnTrampa = false;
    private bool estaMuerto = false;

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

    [Header("Daño")]
    public int dañoPorTrampa = 10;
    public float intervalosDaño = 1f;
    public float limiteCaidaY = -10f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (estaMuerto) return;

        rb.rotation = 0f;

        // Verificar caída al vacío
        if (transform.position.y < limiteCaidaY)
        {
            OnMuerte();
            return;
        }

        // Daño por trampa cada X segundos
        if (estaEnTrampa)
        {
            timerDaño -= Time.deltaTime;
            if (timerDaño <= 0f)
            {
                RecibirDaño(dañoPorTrampa);
                timerDaño = intervalosDaño;
            }
        }

        if (estaDashing) return;

        moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        velocidadActual = Input.GetKey(KeyCode.LeftShift) ? velocidadCorrer : velocidad;

        if (moveX != 0)
        {
            transform.localScale = new Vector3(moveX > 0 ? 1 : -1, 1, 1);
            SoundManager.Instance.PlayPasos(Input.GetKey(KeyCode.LeftShift));
        }
        else
        {
            SoundManager.Instance.StopPasos();
        }

        anim.SetFloat("Movimiento", Mathf.Abs(moveX), 0.1f, Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && puedeDash)
            StartCoroutine(Dash());

        Saltar();
    }

    void FixedUpdate()
    {
        if (estaMuerto) return;

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
                SoundManager.Instance.PlaySaltar();
            }
            else if (puedeDoubleSalto)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
                anim.SetTrigger("Saltar");
                SoundManager.Instance.PlaySaltar();
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Trampa"))
        {
            estaEnTrampa = true;
            timerDaño = 0f;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Trampa"))
            estaEnTrampa = false;
    }

    protected override void OnStatsModificados()
    {
        Debug.Log($"Player - Karma: {karma} | Sanidad: {sanidad}");
    }

    protected override void OnMuerte()
    {
        if (estaMuerto) return;
        estaMuerto = true;

        Entidad.OnEntidadMuerta?.Invoke(this);
        SoundManager.Instance.PlayDerrota();
        SoundManager.Instance.StopPasos();

        // Congelar player sin desactivar el GameObject
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
        GetComponent<Collider2D>().enabled = false;
        enabled = false;

        // Coroutine desde SoundManager que sigue activo
        SoundManager.Instance.StartCoroutine(CargarDerrota());
    }

    System.Collections.IEnumerator CargarDerrota()
    {
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Derrota");
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