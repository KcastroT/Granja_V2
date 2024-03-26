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

    void Update()
    {
    }

    void ActualizarTextoMoneda()
    {
        textoMoneda.text = moneda + "$";
    }
}
