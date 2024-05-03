/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir este namespace para trabajar con elementos UI

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
        // btnCropMaizCanvas.interactable = interactable;
        // btnCropCebadaCanvas.interactable = interactable;
        // btnCropZanahoriaCanvas.interactable = interactable;
        // btnCropTrigoCanvas.interactable = interactable;
    }
}
