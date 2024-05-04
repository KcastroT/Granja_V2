/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using UnityEngine;
using Contador;
using WorldTime;

//Clase para manejar los tiles interactivos
public class Tile : MonoBehaviour { 
    [SerializeField] private GameObject _highlight;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _baseColor;


    public bool IsTouched=false;
    
    //Función para inicializar el tile
    public void Init() {
        _renderer.color = _baseColor;
        _highlight.SetActive(false);
        IsTouched=false;
    }

    void OnMouseEnter() {
        _highlight.SetActive(true);
        IsTouched=true;   
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
        IsTouched=false;
    }

    
}