using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; // Necessary for UI manipulation
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

        
        if (possibleEvents.Count == 0 || totalWeight <= 0)
        {
            Debug.LogWarning("No events are available or all events have a weight of zero.");
            return;
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
                    dialogTrigger.dialog = gameEvent.dialog; 
                    dialogTrigger.TriggerDialog(); 
                }
                gameEvent.thisEvent.Invoke(); 
                return;
            }
        }
    }
}
