
using UnityEngine;
using UnityEngine.EventSystems;

// DragMaiz gestiona la funcionalidad de arrastrar y soltar para un objeto de maíz en la interfaz de usuario.
public class DragMaiz : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Transform parentAfterDrag; // Almacena la referencia al padre original del objeto para restaurarlo después del arrastre.
    public Vector2 posInicial; // Almacena la posición inicial del objeto para restaurarlo si se suelta.
    public static bool isDragging = false; // Estado para indicar si el objeto está siendo arrastrado.

    public static bool canDrag = false; // Controla si el objeto puede ser arrastrado.

    void Start() {
        canDrag = true; // Habilita el arrastre desde el inicio.
    }

    // Se llama al iniciar el arrastre.
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(canDrag){
            Debug.Log("Begin drag");
            parentAfterDrag = transform.parent; // Guarda el padre actual del objeto.
            posInicial = transform.position; // Guarda la posición inicial.
            transform.SetParent(transform.root); // Mueve el objeto al root para evitar problemas de renderizado.
            transform.SetAsLastSibling(); // Asegura que el objeto se renderice sobre otros elementos de la interfaz.
            isDragging = true; // Establece el estado de arrastre a verdadero.
        }
    }

    // Se llama durante el arrastre.
    public void OnDrag(PointerEventData eventData)
    {
        if(canDrag){
            Debug.Log("Dragging");
            transform.position = Input.mousePosition; // Actualiza la posición del objeto a la posición del cursor.
            isDragging = true; // Mantiene el estado de arrastre a verdadero.
        }
    }

    // Se llama al finalizar el arrastre.
    public void OnEndDrag(PointerEventData eventData)
    {
        if(canDrag){
            Debug.Log("End drag");
            transform.SetParent(parentAfterDrag); // Restaura el padre original del objeto.
            isDragging = false; // Establece el estado de arrastre a falso.
        }
        transform.position = posInicial; // Restaura la posición inicial.
    }

    // Se llama cuando se suelta el objeto.
    public void OnDrop(PointerEventData eventData)
    {
        if(!canDrag) { // Si no se puede arrastrar, restaura la posición inicial.
            transform.position = posInicial;
        }

        Debug.Log("Drop");
        transform.position = posInicial; // Asegura que el objeto regrese a su posición inicial al soltar.
    }
}
