/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
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
    public GameObject pantallaInicio;
    public GameObject opcionesPanel;
    public TMP_InputField nameInputField; // Nombre del jugador
    public TMP_InputField apellidoInputField; // Apellido del jugador
    public TMP_InputField YearInputField; //Año de nacimiento
    public TMP_InputField emailInputField;
    public TMP_InputField generoInputField;

    public GameObject musicaFondo;
    public GameObject musicaAmbiente;



    public sistemaMoneda moneda;

    public GameObject HUD;
    public string nombre; // Variable to store the input name
    public string apelllido; // Variable to store the input last name
    public string año; // Variable to store the input year
    public string email; // Variable to store the input email
    public string genero; // Variable to store


    public string modoDeJuego;

    public int contadorDeDias = 0;

    public GameObject timer;

    public GameObject tutorialPanel;

    public GameObject VentaPanel;

    public GameObject VentaBalance;

    public GameObject Pregunta;

    public bool ReiniciarConta = false;

    public bool GameStarted = false;


    public bool TutorialActive = false;
    public bool PreguntaActive = false;

    public GameObject eventManager;

    public GameObject gameToDB;
    public sistemaPregunta sistemaPregunta;
    public ValidarRespuesta validarRespuesta;

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
        GameStarted = false;

        StartCoroutine(ShowPantallaInicioWithDelay());
        contadorDeDias = 0;
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
        MostrarOpcionesPanel();
        yield return new WaitUntil(() => GameStarted == true);
        ToggleHUD(true, true);


    }

    //Función para mostrar la pantalla de inicio con un delay
    IEnumerator ShowPantallaInicioWithDelay()
    {
        ToggleHUD(false);
        yield return new WaitForSeconds(1.5f);
        CargarPantalladeInicio();
        yield return new WaitUntil(() =>
            !string.IsNullOrEmpty(nameInputField.text) &&
            !string.IsNullOrEmpty(apellidoInputField.text) &&
            !string.IsNullOrEmpty(YearInputField.text) &&
            !string.IsNullOrEmpty(emailInputField.text) &&
            !string.IsNullOrEmpty(generoInputField.text)
        );
        Debug.Log("Todos los campos han sido llenados correctamente.");
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        nombre = nameInputField.text;
        apelllido = apellidoInputField.text;
        año = YearInputField.text;
        email = emailInputField.text;
        genero = generoInputField.text;
        musicaAmbiente.GetComponent<AudioSource>().Play();
        musicaFondo.GetComponent<AudioSource>().Play();
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
        StartCoroutine(gameToDB.GetComponent<GameToDB>().UploadUser(nombre, apelllido, email, "-.", año, genero));
    }

    public void AumentoDeDias()
    {
        contadorDeDias++;
        print("Día " + contadorDeDias);
        StartCoroutine(SacarPregunta());
    }

    public bool GetTutorialStatus()
    {
        return TutorialActive;
    }

    public void OnAnswerButtonClicked()
    {

        StartCoroutine(DelayedSacarNoticia());


        StartCoroutine(UploadAndLog());
    }

    private IEnumerator UploadAndLog()
    {

        yield return StartCoroutine(gameToDB.GetComponent<GameToDB>().UploadQuestion(
            gameToDB.GetComponent<GameToDB>().userID,
            sistemaPregunta.GetCurrentPregunta().pregunta));


        yield return StartCoroutine(gameToDB.GetComponent<GameToDB>().UploadAnswer(
            gameToDB.GetComponent<GameToDB>().questID,
            validarRespuesta.SelectedAnswer(),
            validarRespuesta.IsCorrectAnswer()));



        Debug.Log("PREGUNTA \n User ID:" + gameToDB.GetComponent<GameToDB>().userID + "\n" +
                "content: " + sistemaPregunta.GetCurrentPregunta().pregunta);

        Debug.Log("RESPUESTA \n QuestID: " + gameToDB.GetComponent<GameToDB>().questID + "\n" +
            "content: " + validarRespuesta.SelectedAnswer() + "\n" +
            "is_correct: " + validarRespuesta.IsCorrectAnswer());
    }

    //Función para sacar una noticia con un delay
    IEnumerator DelayedSacarNoticia()
    {

        yield return new WaitForSeconds(2);
        Pregunta.SetActive(false);


        StartCoroutine(SacarNoticia());
    }

    //Función para sacar una noticia
    IEnumerator SacarNoticia() 
    {
        yield return new WaitForSeconds(1f);
        eventManager.SetActive(true);
        eventManager.GetComponent<EventManager>().TriggerRandomEvent();
        if (moneda.BarraDeuda.value >= 300)
        {
            PrenderBalanceunitario();
        }
    }

    //Función para sacar pregunta
    IEnumerator SacarPregunta()
    {
        yield return new WaitForSeconds(4f);
        Pregunta.SetActive(true);
        ToggleHUD(true, false);
    }

    //Función para cargar la pantalla de inicio
    public void CargarPantalladeInicio()
    {
        pantallaInicio.SetActive(true);
    }

    public void PrenderBalance()
    {
        if (contadorDeDias >= 6)
        {
            StartCoroutine(verVentanaBalance());
        }

    }

    public void PrenderBalanceunitario()
    {
        if (moneda.BarraDeuda.value >= 300)
        {
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

    // Función para mostrar el panel de ventas
    IEnumerator verVentanaPanel()  
    {
        yield return new WaitForSeconds(0.5f);
        VentaPanel.SetActive(true);
    }

    // Función para mostrar el panel de opciones
    public void MostrarOpcionesPanel()
    {
        pantallaInicio.SetActive(false);
        opcionesPanel.SetActive(true);

    }

    // Función para obtener el modo de juego
    public void GetModoDeJuego(string modo)
    {
        modoDeJuego = modo;
    }

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

    // Comienza un nuevo juego, restableciendo todos los contadores y estados necesarios.
    public void NuevoJuego()
    {
        StartCoroutine(gameToDB.GetComponent<GameToDB>().UploadGame(
             gameToDB.GetComponent<GameToDB>().userID,
             modoDeJuego,
             moneda.moneda
        ));
        eventManager.SetActive(false);

        StartCoroutine(IniciarSinTutorial());

    }

    public string GetModoDeJuego()
    {
        return modoDeJuego;
    }
}