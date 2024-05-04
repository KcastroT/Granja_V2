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

// GameEvent define un evento jugable dentro del juego que puede ser desencadenado.
[System.Serializable] // Asegura que este tipo se pueda serializar y visualizar en el editor de Unity.
public class GameEvent
{
    public string eventName; // Nombre del evento, útil para identificación y depuración.
    public UnityEvent thisEvent; // UnityEvent a invocar cuando se desencadena este evento, permitiendo una fácil configuración de respuestas al evento.
    public Dialog dialog; // Dialog asociado con el evento, que puede ser activado para mostrar narrativas o instrucciones específicas del evento.
}
