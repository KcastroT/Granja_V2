/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; 
using TMPro;
using SystemRandom = System.Random; 

//Clase que representa el sistema de eventos en el juego
public class EventManager : MonoBehaviour
{
    public List<GameEvent> possibleEvents;
    public DialogTrigger dialogTrigger; 

    private SystemRandom random = new SystemRandom(); 

    public void TriggerRandomEvent()
    {
       
        if (possibleEvents.Count == 0)
        {
            Debug.LogWarning("No events are available.");
            return; 
        }

        if (FindObjectOfType<GameManager>().GetTutorialStatus())
        {
            Debug.LogWarning("Tutorial is active. No events will be triggered.");
            return; 
        }

        int randomIndex = random.Next(0, possibleEvents.Count); 
        Debug.Log("Random index: " + randomIndex);
        
        GameEvent selectedEvent = possibleEvents[randomIndex];

       
        if (selectedEvent.dialog != null)
        {
            dialogTrigger.dialog = selectedEvent.dialog; 
            dialogTrigger.TriggerDialog(); 
        }
        selectedEvent.thisEvent.Invoke(); 
    }
}
