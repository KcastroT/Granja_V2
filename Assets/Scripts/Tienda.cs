using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuTienda;
    

    public void OpenTienda()
    {
        // Activar el menú de la tienda
        MenuTienda.SetActive(true);
        
        // Pausar el juego
        Time.timeScale = 0;
    }

    public void CloseTienda()
    {
        // Desactivar el menú de la tienda
        MenuTienda.SetActive(false);
        
        // Reanudar el juego
        Time.timeScale = 1;
    }
}
