
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Clase que maneja el balance del jugador
public class sistemaMoneda : MonoBehaviour
{
    public int moneda;
    public int dineroNoticias;
    public TextMeshProUGUI textoMoneda;
    public Slider BarraDeuda;
    public GameObject VentaBalance;
    public TextMeshProUGUI MensajeEnding;
    public GameObject FuegosArtificialesContainer;


    //Al iniciar el juego, se inicializa el valor de la moneda y se actualiza el texto
    void Start()
    {
        moneda = 400;
        dineroNoticias = 0;
        if (textoMoneda == null)
            textoMoneda = GetComponent<TextMeshProUGUI>();

        if (textoMoneda != null)
            ActualizarTextoMoneda();
            ActualizarSlider();

        if (BarraDeuda != null)
        {
            BarraDeuda.minValue = 0;  // Valor mínimo
            BarraDeuda.maxValue = 300;  // Valor máximo fijo
            BarraDeuda.value = Mathf.Max(0, -moneda);  // Valor inicial, asegurando que no sea negativo
        }
    }


    public void ReiniciarDinero()
    {
        moneda = 0;
        ActualizarTextoMoneda();
        ActualizarSlider();
    }

    //Al perder o ganar, se muestra un mensaje
    public void MostrarEnding(){
        if (moneda < 0)
        {
            MensajeEnding.text= "Perdiste esta partida".ToString();
        }else{
            MensajeEnding.text= "Ganaste esta partida".ToString();

        }
    }


    public void RestarMonedas(int cantidad)
    {
        Debug.Log("Restando " + cantidad + " monedas.");
        moneda -= cantidad;
        ActualizarTextoMoneda();
        ActualizarSlider();
    }


    public void AñadirMonedas(int cantidad)
    {
        Debug.Log("Añadiendo " + cantidad + " monedas.");
        moneda += cantidad;
        ActualizarTextoMoneda();
        ActualizarSlider();
    }

    public void SumarMonedas(int cantidad)
    {
        moneda += cantidad;
        ActualizarTextoMoneda();
        ActualizarSlider();
    }


   
    //Funcion para mostrar ajustar la barra de deudas
    public void ActualizarSlider()
    {
        if (moneda < 0)
        {
            BarraDeuda.value = Mathf.Min(300, -moneda); // Convierte monedas a positivo y limita a 300

        }
        else
        {
            BarraDeuda.value = 0;
        }
    }

    void ActualizarTextoMoneda()
    {
        textoMoneda.text = moneda + "$";
    }
}