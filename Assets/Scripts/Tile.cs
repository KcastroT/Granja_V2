using UnityEngine;
using Contador;
using WorldTime;

public class Tile : MonoBehaviour { 
    //Este codigo namas hace que se resalte el tile cuando se pase el mouse por encima
    //no tiene ninguna otra funcion, no plantes nada aqui y no hagas nada con contadores

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
    //Debug.Log("Mouse enter"); 
    IsTouched=true;   
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        IsTouched=false;
    }

    
}