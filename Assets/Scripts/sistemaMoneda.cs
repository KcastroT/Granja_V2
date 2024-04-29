using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class sistemaMoneda : MonoBehaviour
{
    public int moneda;
    public int dineroNoticias;
    public TextMeshProUGUI textoMoneda;
    public Slider BarraDeuda;
    public GameObject VentaBalance;
    public TextMeshProUGUI MensajeEnding;
    public GameObject FuegosArtificialesContainer;


    void Start()
    {
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
        moneda = 50;
        ActualizarTextoMoneda();
        ActualizarSlider();
    }

    public void MostrarEnding(){
        if (moneda < 0)
        {
            MensajeEnding.text= "Perdiste esta partida".ToString();
        }else{
            MensajeEnding.text= "Ganaste esta partida".ToString();
            //activar Fuegos Artificiales

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
    public void RestarNarcos()
    {
        int monedaspasadas = moneda;//variable que usaremos solo para imprimir la transaccion de monedas
        moneda -= 20;
        dineroNoticias -= 20;
        ActualizarTextoMoneda();
        ActualizarSlider();

        Debug.Log("Transaccion: $" + monedaspasadas + " - $20 = $" + moneda);
    }
    public void AñadirLluvia()
    {
        int monedaspasadas = moneda;//variable que usaremos solo para imprimir la transaccion de monedas
        moneda += 30;
        dineroNoticias += 30;
        ActualizarTextoMoneda();
        ActualizarSlider();
        Debug.Log("Transaccion: $" + monedaspasadas + " + $35 = $" + moneda);
    }
    public void RestarSequia()
    {
        int monedaspasadas = moneda;//variable que usaremos solo para imprimir la transaccion de monedas
        moneda -= 30;
        dineroNoticias -= 30;
        ActualizarTextoMoneda();
        ActualizarSlider();

        Debug.Log("Transaccion: $" + monedaspasadas + " - $30 = $" + moneda);
    }

    public void SumarMonedas(int cantidad)
    {
        moneda += cantidad;
        ActualizarTextoMoneda();
        ActualizarSlider();
    }

    public void SumarConCondicion(int cantidad)
    {
        string modoDeJuego = GameManager.Instance.modoDeJuego; // Correct access of a static member
        if (modoDeJuego == "Verqor")
        {
            moneda += cantidad;
            ActualizarTextoMoneda();
            ActualizarSlider();



        }
        else if (modoDeJuego == "Tradicional")
        {
            moneda += (int)(cantidad * 0.5);
            ActualizarTextoMoneda();
            ActualizarSlider();


        }
        else
        {
            moneda += 0;
            ActualizarTextoMoneda();
            ActualizarSlider();


        }
    }

    public void RestarConCondicion(int cantidad)
    {
        string modoDeJuego = GameManager.Instance.modoDeJuego; // Correct access of a static member

        if (modoDeJuego == "Verqor")
        {
            moneda -= cantidad;
            ActualizarTextoMoneda();
            ActualizarSlider();

        }
        else if (modoDeJuego == "Tradicional")
        {
            moneda -= (int)(cantidad * 0.5);
            ActualizarTextoMoneda();
            ActualizarSlider();

        }
        else
        {
            moneda -= (int)(cantidad * 0.25);
            ActualizarTextoMoneda();
            ActualizarSlider();

        }
    }

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