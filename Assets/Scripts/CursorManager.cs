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
using UnityEngine.EventSystems;

// La clase HoverUI maneja el cambio del cursor cuando el usuario pasa el ratón sobre un objeto específico en la UI.
public class HoverUI : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D customeCursor; // Textura personalizada para el cursor.

    // Se llama cuando el cursor entra en el área del elemento UI que tiene este componente.
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Establece el cursor personalizado.
        Cursor.SetCursor(customeCursor, Vector2.zero, CursorMode.Auto);
    }

    // Se llama cuando el cursor sale del área del elemento UI que tiene este componente.
    public void OnPointerExit(PointerEventData eventData)
    {
        // Restablece el cursor a su forma predeterminada.
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
