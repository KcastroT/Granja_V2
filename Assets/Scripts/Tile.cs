using UnityEngine;
using Contador;

public class Tile : MonoBehaviour {

    [SerializeField] private GameObject _highlight;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _baseColor;


    public bool IsTouched=false;
    public void Init() {
        _renderer.color = _baseColor;
        _highlight.SetActive(false);
        IsTouched=false;
    }

    void OnMouseEnter() {
    _highlight.SetActive(true);
    Debug.Log("Mouse enter");
    IsTouched = true;
    contadorMaiz();
}

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        IsTouched=false;
    }

    void contadorMaiz() 
    {
        if (IsTouched && DragMaiz.isDragging)
        {
            Contadores contadores = GameObject.FindObjectOfType<Contadores>();
            contadores.DecrementarContadorMaiz();
        }
    }
}