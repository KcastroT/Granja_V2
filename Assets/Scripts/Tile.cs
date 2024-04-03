using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    [SerializeField] private GameObject _highlight;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _baseColor;

    public void Init() {
        _renderer.color = _baseColor;
        _highlight.SetActive(false);
    }

    void OnMouseEnter() {
        _highlight.SetActive(true);
        Debug.Log("Mouse enter");
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}