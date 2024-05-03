/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using UnityEngine;
using TMPro;

public class PausaMenu : MonoBehaviour
{
    public GameObject pausaPanel;

    private bool pausaActiva = false;

    private void Update()
    {
        // Detectar si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape) && pausaActiva)
        {
            Pause();
        }
    }

    public void Pause()
    {
        pausaActiva = !pausaActiva; // Alternar el estado de la pausa

        if (pausaActiva)
        {
            // Activar el panel de pausa y pausar el juego
            pausaPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            // Desactivar el panel de pausa y reanudar el juego
            pausaPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    // Este método puede ser llamado desde un botón en el menú de pausa para desactivar la pausa
    public void Continue()
    {
        pausaActiva = false;
        pausaPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
