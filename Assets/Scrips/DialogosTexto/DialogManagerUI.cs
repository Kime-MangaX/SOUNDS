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
        // SetDialogNodes(currentNode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button("Set Dialog Nodes")]
    public void SetDialogNodes(DialogNode node)
    {
        TextPanel.SetActive(true);  
        Text.text = node.Dialogo;

        Sanidad.OnStatsChange?.Invoke(node.KarmaValue, node.SanidadValue);

        ResetList();

        if (node.Options.Count <= 0)
        {
            Debug.Log("No options Available");
            Invoke(nameof(ResetDialogs) ,  4);
            return;
        }


        for (int i = 0; i < node.Options.Count; i++)
        {
            int index = i;
            DIalogUI dialogUI = Instantiate(OptionPrefab, OptionsParent);
            options.Add(dialogUI);
            dialogUI.Set(node.Options[index].OptionText);
            dialogUI.Option.onClick.AddListener(() => SetDialogNodes(node.Options[index].NextNode));
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
