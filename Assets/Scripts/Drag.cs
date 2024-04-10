using UnityEngine;
using UnityEngine.EventSystems;

public class DragMaiz : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    Transform parentAfterDrag;
    Vector2 posInicial;
    public static bool isDragging = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfterDrag = transform.parent;
        posInicial = transform.position;
        transform.SetParent(transform.root); transform.SetAsLastSibling();
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
        isDragging = true;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        isDragging = false;
    }
    //haz que cuando suelte el objeto se regrese a su lugar
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        transform.position = posInicial;
    }


}

