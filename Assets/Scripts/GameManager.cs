using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Este script contiene todas las variables y funciones globales del juego
    public static GameManager Instance {get; private set;}
    public int saldo;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else{
            Debug.Log("Hay más de un GameManager en escena!");
        }
    }

    
    
}   


