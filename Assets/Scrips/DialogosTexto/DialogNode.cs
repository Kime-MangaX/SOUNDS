
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogNode", menuName = "Scriptable Objects/DialogNode")]
public class DialogNode : ScriptableObject
{
    [TextArea(3,10)]
    public string Dialogo;
    public List<DialogOption> Options = new();
}

[Serializable]
public struct DialogOption
{
    public int KarmaValue;
    public int SanidadValue;
    public string OptionText;
    public DialogNode NextNode;
}
