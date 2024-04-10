using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Contadores
{
public class Contadores : MonoBehaviour
{

    public sistemaMoneda sistemaMoneda;
    public TextMeshProUGUI textoContadorMaiz;
    public int contadorMaiz = 0;

    public void IncrementarContadorMaiz()
    {
        contadorMaiz++;
        ActualizarTextoContadorMaiz();

        sistemaMoneda.RestarMonedas(1);
    }

    public void DecrementarContadorMaiz()
    {
        contadorMaiz--;
        if (contadorMaiz < 0)
        {
            contadorMaiz = 0;

        }
        ActualizarTextoContadorMaiz();
    }

    private void ActualizarTextoContadorMaiz()
    {
        textoContadorMaiz.text = contadorMaiz.ToString();
    }
}
}
