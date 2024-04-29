using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public List<UnityEvent> events;
    private int currentEventIndex = 0;  // Index to track the current event

    public void Start()
    {
        TriggerDialog();
    }
    
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }

    // Call this method when the continue button is pressed
    public void TriggerNextEvent()
    {
        // Check if the tutorial is active
        if (FindObjectOfType<GameManager>().GetTutorialStatus())
        {
            // Check if the current index is within the bounds of the list
            if (currentEventIndex < events.Count)
            {
                events[currentEventIndex].Invoke();  // Trigger the current event
                currentEventIndex++;  // Move to the next event
            }
        }
    }
}
