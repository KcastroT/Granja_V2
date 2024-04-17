using UnityEngine;
using UnityEngine.EventSystems;
public class DragZanahoria : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    Transform parentAfterDrag;
    public Vector2 posInicial;

    public static bool isDragging = false;

    public static bool canDrag = false;


    void Start() {
    canDrag = true; // Asegúrate de que el arrastre esté habilitado desde el inicio
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if(canDrag){
            Debug.Log("Begin drag");
            parentAfterDrag = transform.parent;
            posInicial = transform.position;
            transform.SetParent(transform.root); transform.SetAsLastSibling();
            isDragging = true;
        }

        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(canDrag){
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
        isDragging = true;



        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if(canDrag){
        Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        isDragging = false;
        }
        transform.position = posInicial;
    }
    //haz que cuando suelte el objeto se regrese a su lugar
    public void OnDrop(PointerEventData eventData)
    {
        if(!canDrag){transform.position = posInicial;}

        Debug.Log("Drop");
        transform.position = posInicial;
    }


}
