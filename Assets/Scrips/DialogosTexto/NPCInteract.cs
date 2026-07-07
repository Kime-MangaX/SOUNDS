using UnityEngine;

public class NPCInteract : MonoBehaviour, IInteractuable
{
    public DialogNode firstNode;
    public float rangoInteraccion = 2f;

    private DialogManagerUI dialogManager;
    private Transform player;
    private bool playerCerca = false;

    public bool PuedeInteractuar => playerCerca;

    public void Interactuar()
    {
        dialogManager.SetDialogNodes(firstNode);
    }

    void Start()
    {
        dialogManager = FindAnyObjectByType<DialogManagerUI>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distancia = Vector2.Distance(transform.position, player.position);
        playerCerca = distancia <= rangoInteraccion;

        if (playerCerca && Input.GetKeyDown(KeyCode.E))
            Interactuar();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoInteraccion);
    }
}