
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; 
using TMPro;
using SystemRandom = System.Random; 

// EventManager gestiona y desencadena eventos aleatorios dentro del juego.
public class EventManager : MonoBehaviour
{
    public List<GameEvent> possibleEvents; // Lista de posibles eventos que pueden ser desencadenados.
    public DialogTrigger dialogTrigger; // Componente que activa diálogos relacionados con eventos.

    private SystemRandom random = new SystemRandom(); // Generador de números aleatorios para seleccionar eventos.

    // Desencadena un evento aleatorio de la lista de eventos posibles.
    public void TriggerRandomEvent()
    {
        // Verifica si hay eventos disponibles.
        if (possibleEvents.Count == 0)
        {
            Debug.LogWarning("No events are available."); // Advertencia si no hay eventos.
            return; 
        }

        // Verifica si el tutorial está activo para evitar desencadenar eventos durante este.
        if (FindObjectOfType<GameManager>().GetTutorialStatus())
        {
            Debug.LogWarning("Tutorial is active. No events will be triggered."); // Advertencia si el tutorial está activo.
            return; 
        }

        // Selecciona un índice aleatorio de la lista de eventos.
        int randomIndex = random.Next(0, possibleEvents.Count); 
        Debug.Log("Random index: " + randomIndex);
        
        // Obtiene el evento seleccionado basado en el índice aleatorio.
        GameEvent selectedEvent = possibleEvents[randomIndex];

        // Si el evento seleccionado tiene un diálogo asociado, lo desencadena.
        if (selectedEvent.dialog != null)
        {
            dialogTrigger.dialog = selectedEvent.dialog; 
            dialogTrigger.TriggerDialog(); 
        }
        // Invoca el evento Unity asociado con el evento seleccionado.
        selectedEvent.thisEvent.Invoke(); 
    }
}
