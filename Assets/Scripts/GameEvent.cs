/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameEvent
{
    public string eventName;
     // Used to adjust the likelihood of this event
    public UnityEvent thisEvent; // UnityEvent to invoke when this event is triggered

    public Dialog dialog;
}