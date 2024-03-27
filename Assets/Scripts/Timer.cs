using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using System;

public class Timer : MonoBehaviour
{
    public float timeValue = 120;
    public int etapa = 0;
    public TextMeshProUGUI timeText;

    private float etapaTimer = 0f; // Contador para controlar cuándo cambiar de etapa.

    void Start()
    {
        etapa = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

        // Incrementar el contador de etapa.
        etapaTimer += Time.deltaTime;

        // Si el contador alcanza 1 segundo (o más), actualiza la etapa.
        if(etapaTimer >= 1f)
        {
            EtapaChanger();
            etapaTimer = 0f; // Restablecer el contador para el próximo segundo.
        }
    }

    void EtapaChanger()
    {
        // Aquí puedes añadir la lógica para cambiar de etapa. 
        // Este ejemplo simplemente incrementa `etapa`.
        etapa++;
        if(etapa >= 5)
        {
            etapa = 0;
        }
        Debug.Log($"Cambio de etapa: {etapa}");
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
