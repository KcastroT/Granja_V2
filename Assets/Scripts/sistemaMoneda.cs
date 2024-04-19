using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sistemaMoneda : MonoBehaviour
{
    public int moneda;
    public int dineroNoticias;
    public TextMeshProUGUI textoMoneda;

    void Start()
    {   
        dineroNoticias = 0;
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

    public void AñadirMonedas(int cantidad)
    {
        Debug.Log("Añadiendo " + cantidad + " monedas.");
        moneda += cantidad;
        ActualizarTextoMoneda();
    }
    public void RestarNarcos(){
        int monedaspasadas = moneda;//variable que usaremos solo para imprimir la transaccion de monedas
        moneda -= 20;
        dineroNoticias -= 20;
        ActualizarTextoMoneda();
        Debug.Log("Transaccion: $"+monedaspasadas+" - $20 = $"+moneda);
    }
    public void AñadirLluvia(){
        int monedaspasadas = moneda;//variable que usaremos solo para imprimir la transaccion de monedas
        moneda += 30;
        dineroNoticias += 30;
        ActualizarTextoMoneda();
        Debug.Log("Transaccion: $"+monedaspasadas+" + $35 = $"+moneda);
    }
    public void RestarSequia(){
        int monedaspasadas = moneda;//variable que usaremos solo para imprimir la transaccion de monedas
        moneda -= 30;
        dineroNoticias -= 30;
        ActualizarTextoMoneda();
        Debug.Log("Transaccion: $"+monedaspasadas+" - $30 = $"+moneda);
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
