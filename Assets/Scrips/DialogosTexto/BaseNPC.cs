using Sirenix.OdinInspector;
using UnityEngine;

public class BaseNPC : MonoBehaviour
{
    public DialogNode StartetNode;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    [Button]
    public void DialogOption()
    {
       GameManager.Instance.DialogManagerUI.SetDialogNodes(StartetNode);
    }
}
