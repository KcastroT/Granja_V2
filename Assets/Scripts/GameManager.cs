using System.Collections;
using UnityEngine;
using TMPro;
using HappyHarvest;

public class GameManager : MonoBehaviour
{
    // Este script contiene todas las variables y funciones globales del juego
    
    public static GameManager Instance { get; private set; }

    public int saldo;
    public GameObject pantallaInicio;
    public GameObject opcionesPanel;
    public TMP_InputField nameInputField; // TMP_InputField instead of InputField

    public GameObject HUD;
    public string nombre; // Variable to store the input name

    public string modoDeJuego;

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
        StartCoroutine(ShowPantallaInicioWithDelay());
    }

    IEnumerator ShowPantallaInicioWithDelay()
    {
        yield return new WaitForSeconds(1.5f);
        CargarPantalladeInicio();
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        nombre = nameInputField.text; // Store the input name
        yield return new WaitForSeconds(1.5f);
        MostrarOpcionesPanel();
        HUD.SetActive(true);
    }

    public void CargarPantalladeInicio()
    {   
        HUD.SetActive(false);
        pantallaInicio.SetActive(true);
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
}
