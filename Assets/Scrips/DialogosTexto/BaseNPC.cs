using UnityEngine;

public class BaseNPC : MonoBehaviour
{
    public DialogNode StartetNode;
    public DialogNode currentNode;
    void Start()
    {
        currentNode = StartetNode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DialogOption(int value)
    {
        currentNode = currentNode.Options[value].NextNode;
    }
}
