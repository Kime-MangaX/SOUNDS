using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DIalogUI : MonoBehaviour
{

    public TextMeshProUGUI Text;
    public Button Option;
    public DialogNode DialogNode;


    public void Set(string text)
    {
        Text.text = text;
        
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
