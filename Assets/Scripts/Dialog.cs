
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que representa los dialogos de los personajes
[System.Serializable]
public class Dialog 
{
    public string name; //Nombre del personaje

    [TextArea(3, 10)]
    public string[] sentences; //Arreglo de oraciones que conforman el dialogo

}
