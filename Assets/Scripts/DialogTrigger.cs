
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// La clase DialogTrigger gestiona el inicio y la progresión de diálogos junto con eventos asociados en un juego.
public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog; // Contiene la estructura de diálogo que será mostrada.
    public List<UnityEvent> events; // Lista de eventos de Unity que se dispararán en secuencia.
    private int currentEventIndex = 0;  // Índice para rastrear el evento actual.

    public void Start()
    {
        TriggerDialog(); // Inicia el diálogo al cargar el componente.
    }
    
    // Inicia el diálogo utilizando el gestor de diálogos.
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }

    // Se llama a este método cuando se presiona el botón de continuar.
    public void TriggerNextEvent()
    {
        // Verifica si el tutorial está activo.
        if (FindObjectOfType<GameManager>().GetTutorialStatus())
        {
            // Comprueba si el índice actual está dentro de los límites de la lista.
            if (currentEventIndex < events.Count)
            {
                events[currentEventIndex].Invoke();  // Dispara el evento actual.
                currentEventIndex++;  // Avanza al siguiente evento.
            }
        }
    }
}
