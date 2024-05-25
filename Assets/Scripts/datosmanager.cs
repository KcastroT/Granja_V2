using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class datosmanager : MonoBehaviour
{
    [TextArea(3, 10)]
    public List<string> listaDatosInicial; // Lista temporal para rellenar desde el inspector
    private Queue<string> listaDatos;
    public List<UnityEvent> events;
    public TextMeshProUGUI dialogBox;
    public GameObject PanelDatos;
    public GameManager gameManager;  // Referencia al GameManager
    private int eventIndex = 0;
    private int callCount = 0;

    void Start()
    {
        listaDatos = new Queue<string>(listaDatosInicial); 
        PanelDatos.SetActive(false);
    }

    public void SacarDatos()
    {
        if (gameManager.CuantosDias() > 0)
        {
            PanelDatos.SetActive(true);
            if (listaDatos.Count > 0)
            {
                string dato = listaDatos.Dequeue();
                dialogBox.text = dato;

                if (events.Count > 0)
                {
                    events[eventIndex]?.Invoke();
                    eventIndex = (eventIndex + 1) % events.Count;
                }

                callCount++;
                if (callCount >= 6)
                {
                    callCount = 0; // Reiniciar el contador de llamadas
                    eventIndex = 0; // Reiniciar el índice de eventos
                }
            }
        }
        else
        {
            PanelDatos.SetActive(false);
        }
    }
}
