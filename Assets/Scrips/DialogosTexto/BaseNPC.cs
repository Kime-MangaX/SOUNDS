using Sirenix.OdinInspector;
using UnityEngine;

public class BaseNPC : MonoBehaviour
{
    public DialogNode StartetNode;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button]
    public void DialogOption()
    {
       GameManager.Instance.DialogManagerUI.SetDialogNodes(StartetNode);
    }
}
