
using UnityEngine;
using UnityEngine.UI; 

//Clase para manejar la tienda
public class Tienda : MonoBehaviour
{
    public GameObject MenuTienda;
    private bool tiendaActiva = false;

    // Referencias a los botones
    public Button btnPausa;
    public Button btnTienda;
    public Button btnClock;
    public GameObject btnCropMaizCanvas;
    public GameObject btnCropCebadaCanvas;
    public GameObject btnCropZanahoriaCanvas;
    public GameObject btnCropTrigoCanvas;

    //Función para activar o desactivar la tienda
    public void ToggleTienda()
    {
        tiendaActiva = !tiendaActiva;

        if (tiendaActiva)
        {
            MenuTienda.SetActive(true);
            Time.timeScale = 0; // Pausar el juego
            SetButtonsInteractivity(false); // Desactiva los botones
        }
        else
        {
            MenuTienda.SetActive(false);
            Time.timeScale = 1; // Reanudar el juego
            SetButtonsInteractivity(true); // Reactiva los botones
        }
    }

     public void Continue()
    {
        tiendaActiva = false;
        MenuTienda.SetActive(false);
        Time.timeScale = 1;
    }
    private void SetButtonsInteractivity(bool interactable)
    {
        // Establecer la interactividad de cada botón
        btnPausa.interactable = interactable;
        btnTienda.interactable = interactable;
        btnClock.interactable = interactable;
    }
}
