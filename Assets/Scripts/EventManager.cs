using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; // Necessary for UI manipulation
using TMPro;
using SystemRandom = System.Random; // Alias for System.Random

public class EventManager : MonoBehaviour
{
    public List<GameEvent> possibleEvents;
    public DialogTrigger dialogTrigger; // Reference to the DialogTrigger

    private SystemRandom random = new SystemRandom(); // Create a random object at the class level using the alias

    public void TriggerRandomEvent()
    {
        // Check if there are any events
        if (possibleEvents.Count == 0)
        {
            Debug.LogWarning("No events are available.");
            return; // Exit if no events are available
        }

        if (FindObjectOfType<GameManager>().GetTutorialStatus())
        {
            Debug.LogWarning("Tutorial is active. No events will be triggered.");
            return; // Exit if the tutorial is active
        }

        int randomIndex = random.Next(0, possibleEvents.Count); // Generate a random index using SystemRandom
        Debug.Log("Random index: " + randomIndex);
        // Retrieve the event using the random index
        GameEvent selectedEvent = possibleEvents[randomIndex];

        // Trigger the selected event and its dialog
        if (selectedEvent.dialog != null)
        {
            dialogTrigger.dialog = selectedEvent.dialog; // Set the dialog in the trigger
            dialogTrigger.TriggerDialog(); // Trigger the dialog
        }
        selectedEvent.thisEvent.Invoke(); // Invoke the event
    }
}
