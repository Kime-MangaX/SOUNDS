using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    public DialogNode firstNode;
    public float rangoInteraccion = 2f;

    private DialogManagerUI dialogManager;
    private Transform player;
    private bool playerCerca = false;

    void Start()
    {
        dialogManager = FindAnyObjectByType<DialogManagerUI>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Verificar distancia al player
        float distancia = Vector2.Distance(transform.position, player.position);
        playerCerca = distancia <= rangoInteraccion;

        if (playerCerca && Input.GetKeyDown(KeyCode.E))
        {
            dialogManager.SetDialogNodes(firstNode);
        }
    }

    // Visualizar el rango en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoInteraccion);
    }
}