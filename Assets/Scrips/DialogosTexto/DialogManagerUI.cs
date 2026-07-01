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

    

    [Header("Portrait")]
    public Image PortraitImage;
    public GameObject PortraitPanel;

    void Start()
    {
        TextPanel.SetActive(false);
        PortraitPanel.SetActive(false);
    }

    [Button("Set Dialog Nodes")]
    public void SetDialogNodes(DialogNode node)
    {
        if (node == null)
        {
            ResetDialogs();
            return;
        }

        TextPanel.SetActive(true);
        Text.text = node.Dialogo;

        MostrarPortrait(node.PortraitInicial);

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

            if (node.Options[index].NextNode != null)
            {
                dialogUI.Option.onClick.AddListener(() =>
                {
                    MostrarPortrait(node.Options[index].PortraitAlElegir);

                    Sanidad.OnStatsChange?.Invoke(
                        node.Options[index].KarmaValue,
                        node.Options[index].SanidadValue
                    );

                    SetDialogNodes(node.Options[index].NextNode);
                });
            }
            else
            {
                dialogUI.Option.onClick.AddListener(() =>
                {
                    MostrarPortrait(node.Options[index].PortraitAlElegir);

                    Sanidad.OnStatsChange?.Invoke(
                        node.Options[index].KarmaValue,
                        node.Options[index].SanidadValue
                    );

                    Invoke(nameof(ResetDialogs), 1.5f);
                });
            }
        }
    }

    void MostrarPortrait(Sprite sprite)
    {
        if (sprite != null)
        {
            PortraitImage.sprite = sprite;
            PortraitPanel.SetActive(true);
        }
        else
        {
            PortraitPanel.SetActive(false);
        }
    }

    public void ResetDialogs()
    {
        Text.text = "";
        ResetList();
        TextPanel.SetActive(false);
        PortraitPanel.SetActive(false);
    }

    public void ResetList()
    {
        foreach (var option in options)
            Destroy(option.gameObject);
        options.Clear();
    }
}