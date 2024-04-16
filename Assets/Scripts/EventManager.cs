using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;  // Necessary for UI manipulation
using TMPro;  


public class EventManager : MonoBehaviour
{
    public List<GameEvent> possibleEvents;
    public DialogTrigger dialogTrigger; // Reference to the DialogTrigger
    
    

    
    public void TriggerRandomEvent()
    {
        float totalWeight = 0f;
        foreach (GameEvent gameEvent in possibleEvents)
        {
            totalWeight += gameEvent.probabilityWeight;
        }

        float randomPoint = Random.value * totalWeight;
        float cumulativeWeight = 0f;
        foreach (GameEvent gameEvent in possibleEvents)
        {
            cumulativeWeight += gameEvent.probabilityWeight;
            if (randomPoint <= cumulativeWeight)
            {
                if (gameEvent.dialog != null)
                {
                    dialogTrigger.dialog = gameEvent.dialog; // Set the dialog in the trigger
                    dialogTrigger.TriggerDialog(); // Trigger the dialog
                    gameEvent.thisEvent.Invoke(); // Invoke the event
                }
                break;
            }
        }
    }
}

