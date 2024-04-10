using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sistemaMoneda : MonoBehaviour
{
    public int moneda;
    public TextMeshProUGUI textoMoneda;

    void Start()
    {
        if (textoMoneda == null)
            textoMoneda = GetComponent<TextMeshProUGUI>();

        if (textoMoneda != null)
            ActualizarTextoMoneda();
    }

     public void RestarMonedas(int cantidad)
    {
        Debug.Log("Restando " + cantidad + " monedas.");
        moneda -= cantidad;
        ActualizarTextoMoneda();
    }

    public void SumarMonedas(int cantidad)
    {
        moneda += cantidad;
        ActualizarTextoMoneda();
    }


    void ActualizarTextoMoneda()
    {
        textoMoneda.text = moneda + "$";
    }
}
