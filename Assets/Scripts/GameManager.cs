using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Este script contiene todas las variables y funciones globales del juego

    public static GameManager Instance { get; private set; }
    public GameObject pantallaInicio;
    public GameObject opcionesPanel;
    public TMP_InputField nameInputField; // TMP_InputField instead of InputField
    public sistemaMoneda moneda;

    public GameObject HUD;
    public string nombre; // Variable to store the input name

    public string modoDeJuego;

    public int contadorDeDias = 0;

    public GameObject timer;

    public GameObject tutorialPanel;

    public GameObject VentaPanel;

    public GameObject VentaBalance;

    public bool GameStarted = false;


    public bool TutorialActive = false;

    public GameObject eventManager;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("¡Hay más de un GameManager en escena!");
        }
    }

    public void Start()
    {
        GameStarted = false;

        StartCoroutine(ShowPantallaInicioWithDelay());
        contadorDeDias = 0;
    }

    IEnumerator ShowPantallaInicioWithDelay()
    {
        ToggleHUD(false);
        yield return new WaitForSeconds(1.5f);
        CargarPantalladeInicio();
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        nombre = nameInputField.text;
        yield return new WaitForSeconds(1.5f);
        MostrarOpcionesPanel();
        yield return new WaitUntil(() => GameStarted == true);
        yield return new WaitForSeconds(1.5f);
        tutorialPanel.SetActive(true);
        ToggleHUD(true, false);  // HUD is visible but not interactable
        TutorialActive = true;
        yield return new WaitUntil(() => TutorialActive == false);
        // Wait for tutorial to finish
        ToggleHUD(true, true);  // Make HUD interactable again
        timer.SetActive(true);
        
    }

    public void AumentoDeDias()
    {
        contadorDeDias++;
        print("Día " + contadorDeDias);
        StartCoroutine(SacarNoticia());
    }

    IEnumerator SacarNoticia()  // Function to trigger a random event
    {   
        yield return new WaitForSeconds(4f);
        eventManager.SetActive(true);
        eventManager.GetComponent<EventManager>().TriggerRandomEvent();
        if(moneda.BarraDeuda.value >= 300)
        {
            PrenderBalanceunitario();
        }
    }

    public void CargarPantalladeInicio()
    {
        pantallaInicio.SetActive(true);
    }

    public void PrenderBalance()
    {   
        if (contadorDeDias >= 3){
            StartCoroutine(verVentanaBalance());
            contadorDeDias = 0;
        }
        
    }

    public void PrenderBalanceunitario()
    {
        if(moneda.BarraDeuda.value >= 300){
            StartCoroutine(verVentanaBalance());
        }

    }
    IEnumerator verVentanaBalance()  // Function to trigger a random event
    {   
        yield return new WaitForSeconds(0.5f);
        VentaBalance.SetActive(true);
        
    }

    public void PrenderVentas()
    {
        if (contadorDeDias > 0)
        StartCoroutine(verVentanaPanel());
    }

    IEnumerator verVentanaPanel()  // Function to trigger a random event
    {   
        yield return new WaitForSeconds(0.5f);
        VentaPanel.SetActive(true);
    }

    public void MostrarOpcionesPanel()
    {
        pantallaInicio.SetActive(false);
        opcionesPanel.SetActive(true);

    }

    public void GetModoDeJuego(string modo)
    {
        modoDeJuego = modo;
    }

    public void StartGame()
    {
        GameStarted = true;
    }

    // Supongamos que esta es tu función ToggleHUD
    public void ToggleHUD(bool show, bool interactable = false)
    {
        // Obtain the CanvasGroup component from the HUD
        CanvasGroup hudCanvasGroup = HUD.GetComponent<CanvasGroup>();

        if (show)
        {
            // Make the HUD visible
            hudCanvasGroup.alpha = 1;
            // Set interaction properties based on the parameter
            hudCanvasGroup.blocksRaycasts = interactable;
            hudCanvasGroup.interactable = interactable;
        }
        else
        {
            // Hide the HUD
            hudCanvasGroup.alpha = 0;
            hudCanvasGroup.blocksRaycasts = false;
            hudCanvasGroup.interactable = false;
        }
    }

    public void NuevoJuego()
    {
        SceneManager.LoadScene("Game");
    }

   public string GetModoDeJuego()
   {
       return modoDeJuego;
   }
}