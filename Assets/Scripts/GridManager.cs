
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Clase para manejar el grid de tiles de los cultivos
public class GridManager : MonoBehaviour {
    // Referencias a los prefabs de los tiles
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefabMaiz;
    [SerializeField] private Tile _tilePrefabTrigo;
    [SerializeField] private Tile _tilePrefabCebada;
    [SerializeField] private Tile _tilePrefabZanahoria;


    private Dictionary<Vector2, Tile> _tilesMaiz;
    private Dictionary<Vector2, Tile> _tilesTrigo;
    private Dictionary<Vector2, Tile> _tilesCebada;
    private Dictionary<Vector2, Tile> _tilesZanahoria;

    void Start() {
        GenerateGridMaiz();
        GenerateGridTrigo();
        GenerateGridCebada();
        GenerateGridZanahoria();
    }
    
    // Función para generar el grid de tiles
    void GenerateGridMaiz() {
        _tilesMaiz = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefabMaiz, new Vector3(3.9f+(x * 1.8f), (y * 1.8f)-2.4f), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.Init();

                _tilesMaiz[new Vector2(x, y)] = spawnedTile;
            }
        }
    }

    //Funcion para generar el grid de tiles de trigo
    void GenerateGridTrigo(){
        _tilesTrigo = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefabTrigo, new Vector3(11.6f+(x * 1.8f), (y * 1.8f)-2.4f), Quaternion.identity);
                spawnedTile.name = $"TileTrigo {x} {y}";
                spawnedTile.Init();

                _tilesTrigo[new Vector2(x, y)] = spawnedTile;
            }
        }

    }

    //Funcion para generar el grid de tiles de cebada
    void GenerateGridCebada(){
        _tilesCebada = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefabCebada, new Vector3(11.6f+(x * 1.8f), (y * 1.8f)+4f), Quaternion.identity);
                spawnedTile.name = $"TileCebada {x} {y}";
                spawnedTile.Init();

                _tilesCebada[new Vector2(x, y)] = spawnedTile;
            }
        }

    }

    //Funcion para generar el grid de tiles de zanahoria
    void GenerateGridZanahoria(){
        _tilesZanahoria = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefabZanahoria, new Vector3(3.9f+(x * 1.8f), (y * 1.8f)+4f), Quaternion.identity);
                spawnedTile.name = $"TileZanahoria {x} {y}";
                spawnedTile.Init();

                _tilesZanahoria[new Vector2(x, y)] = spawnedTile;
            }
        }

    }
}