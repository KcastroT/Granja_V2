using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Contadores;


public class Tile : MonoBehaviour {
    [SerializeField] private Contadores.Contadores contadores;

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
    contadores.DecrementarContadorMaiz();
}

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        IsTouched=false;
    }
}