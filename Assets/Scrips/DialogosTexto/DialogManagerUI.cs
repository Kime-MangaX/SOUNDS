using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class DialogManagerUI : MonoBehaviour
{
    public DialogNode currentNode;
    public Transform OptionsParent;
    public GameObject TextPanel;
    public TextMeshProUGUI Text;
    public List<DIalogUI> options;
    public DIalogUI OptionPrefab;

    void Start()
    {
        TextPanel.SetActive(false);
    }

    [Button("Set Dialog Nodes")]
    public void SetDialogNodes(DialogNode node)
    {
        // Protección por si el nodo es null
        if (node == null)
        {
            Debug.LogWarning("El nodo es null, cerrando dialogo.");
            ResetDialogs();
            return;
        }

        TextPanel.SetActive(true);
        Text.text = node.Dialogo;
        ResetList();

        if (node.Options.Count <= 0)
        {
            Debug.Log("No options Available");
            Invoke(nameof(ResetDialogs), 4);
            return;
        }

        for (int i = 0; i < node.Options.Count; i++)
        {
            int index = i;
            DIalogUI dialogUI = Instantiate(OptionPrefab, OptionsParent);
            options.Add(dialogUI);
            dialogUI.Set(node.Options[index].OptionText);

            // Protección: verificar que NextNode no sea null
            if (node.Options[index].NextNode != null)
            {
                dialogUI.Option.onClick.AddListener(() =>
                {
                    // Aplicar karma y sanidad AL ELEGIR la opción
                    Sanidad.OnStatsChange?.Invoke(
                        node.Options[index].KarmaValue,
                        node.Options[index].SanidadValue
                    );
                    SetDialogNodes(node.Options[index].NextNode);
                });
            }
            else
            {
                // Si no hay siguiente nodo, cerrar el dialogo al elegir
                dialogUI.Option.onClick.AddListener(() =>
                {
                    Sanidad.OnStatsChange?.Invoke(
                        node.Options[index].KarmaValue,
                        node.Options[index].SanidadValue
                    );
                    ResetDialogs();
                });
            }
        }
    }

    public void ResetDialogs()
    {
        Text.text = "";
        ResetList();
        TextPanel.SetActive(false);
    }

    public void ResetList()
    {
        foreach (var option in options)
        {
            Destroy(option.gameObject);
        }
        options.Clear();
    }
}