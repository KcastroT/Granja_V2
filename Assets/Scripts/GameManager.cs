
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//Define el comportamiento del juego
public class GameManager : MonoBehaviour
{
    // Este script contiene todas la mayoria variables y funciones globales del juego

    public static GameManager Instance { get; private set; }

    public GameObject musicaFondo;
    public GameObject musicaAmbiente;
    public GameObject HUD;

    public int contadorDeDias = 0;
    private int d = 0; 

    public GameObject timer;

    public GameObject tutorialPanel;

    public GameObject VentaPanel;
    public GameObject VentaBalance;
    public GameObject PreguntaPanel;
    public bool ReiniciarConta = false;
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

    //Función que prepara el juego para iniciar
    public void Start()
    {
        GameStarted = true;
        d=contadorDeDias;
        StartCoroutine(ShowTutorial());
        contadorDeDias = 0;
        print("Día " + contadorDeDias);
    }
    public void Update()
    {
        if (contadorDeDias > d)
        {
            d = contadorDeDias;
            print("Ya paso al Día: " + contadorDeDias);
            StartCoroutine(SacarNoticia());
        }
    }

    public int CuantosDias()
    {
        return contadorDeDias;  
    }

    //Cuando se reinicia el juego se llama a esta función
    IEnumerator IniciarSinTutorial()
    {
        contadorDeDias = 0;
        ReiniciarConta = true; //reiniciar contadores (dinero = 0)
        GameStarted = false;
        TutorialActive = false;
        timer.SetActive(true);
        ToggleHUD(false, false);
        yield return new WaitUntil(() => GameStarted == true);
        ToggleHUD(true, true);


    }

    //Función para mostrar la pantalla de inicio con un delay
    IEnumerator ShowTutorial()
    {
        ToggleHUD(false, false);  // HUD is visible but not interactable
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Todos los campos han sido llenados correctamente.");
        //falta prender un mensaje que digas "CLICK PARA JUGAR"
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0));
        //falta apagar un mensaje que digas "CLICK PARA JUGAR"
        musicaAmbiente.GetComponent<AudioSource>().Play();
        musicaFondo.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => GameStarted == true);
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
    }

    public void OnAnswerButtonClicked()
    {
        StartCoroutine(DelayedSacarNoticia());
    }

    //Función para sacar una noticia con un delay
    IEnumerator DelayedSacarNoticia()
    {

        yield return new WaitForSeconds(2);
        StartCoroutine(SacarNoticia());
    }

    //Función para sacar una noticia
    IEnumerator SacarNoticia() 
    {
        yield return new WaitForSeconds(1.5f);
        eventManager.SetActive(true);
        eventManager.GetComponent<EventManager>().TriggerRandomEvent();
    }

    // //Función para sacar pregunta
    // IEnumerator SacarPregunta()
    // {
    //     yield return new WaitForSeconds(4f);
    //     Pregunta.SetActive(true);
    //     ToggleHUD(true, false);
    // }

    //Función para cargar la pantalla de inicio
    // public void CargarPantalladeInicio()
    // {
    //     pantallaInicio.SetActive(true);
    // }


    public bool GetTutorialStatus()
    {
        return TutorialActive;
    }

    public void PrenderBalance()
    {
        if (contadorDeDias >= 6)
        {
            StartCoroutine(verVentanaBalance());
        }

    }

    // public void PrenderBalanceunitario()
    // {
    //     if (moneda.BarraDeuda.value >= 300)
    //     {
    //         StartCoroutine(verVentanaBalance());
    //     }

    // }
    IEnumerator verVentanaBalance()  // Function to trigger a random event
    {
        yield return new WaitForSeconds(0.5f);
        VentaBalance.SetActive(true);

    }


    public void PrenderVentas()
    {
        if (contadorDeDias > 0){
            StartCoroutine(verVentanaPanel());
        }
    }

    // Función para mostrar el panel de ventas
    IEnumerator verVentanaPanel()  
    {
        yield return new WaitForSeconds(0.5f);
        VentaPanel.SetActive(true);
    }

    // Función para mostrar el panel de opciones
    // public void MostrarOpcionesPanel()
    // {
    //     pantallaInicio.SetActive(false);
    //     opcionesPanel.SetActive(true);

    // }


    // Función para iniciar el juego
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
}