using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefabMaiz;
    [SerializeField] private Tile _tilePrefabTrigo;


    private Dictionary<Vector2, Tile> _tilesMaiz;
    private Dictionary<Vector2, Tile> _tilesTrigo;

    void Start() {
        GenerateGridMaiz();
        GenerateGridTrigo();
    }

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
}