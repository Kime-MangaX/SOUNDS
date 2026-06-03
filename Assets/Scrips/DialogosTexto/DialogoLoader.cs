using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

[System.Serializable]
public class Respueta
{
    public string textoBoton;
    public string npcRespuesta;
}

[System.Serializable]
public class Respuestas
{
    public Respuestas buena;
    public Respuestas neutra;
    public Respuestas mala;
}

[System.Serializable]
public class Dialogo
{
    public int id;
    public string npcTexto;
    public Respueta respuestas;
}

[System.Serializable]
public class NPCDta
{
    public string npcID;
    public List<Dialogo> dialogos;
}


public class DialogoLoader : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
