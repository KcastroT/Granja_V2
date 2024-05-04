/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[System.Serializable]
public class Pregunta
{
    public string pregunta;
    public List<string> opciones;
    public string respuesta_correcta;
}

[System.Serializable]
public class Preguntas
{
    public List<Pregunta> preguntas;
}

//Clase para manejar las preguntas y respuestas
public class sistemaPregunta : MonoBehaviour
{
    public PreguntasManager preguntasManager;
    private Pregunta currentPregunta;
    private Preguntas preguntas;
    private int currentPreguntaIndex;

    void Start()
    {
        //Inicializar la semilla para obtener preguntas aleatorias
        Random.InitState(System.DateTime.Now.Millisecond);

        TextAsset jsonFile = Resources.Load<TextAsset>("preguntas");
        string jsonContent = jsonFile.text;

        preguntas = JsonUtility.FromJson<Preguntas>(jsonContent);

        currentPreguntaIndex = Random.Range(0, preguntas.preguntas.Count);
        currentPregunta = preguntas.preguntas[currentPreguntaIndex];
        preguntasManager.UpdateQuestionAndAnswers(currentPregunta.pregunta, currentPregunta.opciones);
    }

    //
    public Pregunta GetCurrentPregunta()
    {
        return currentPregunta;
    }

    public void GetNextPregunta()
{
    currentPreguntaIndex = (currentPreguntaIndex + 1) % preguntas.preguntas.Count;
    currentPregunta = preguntas.preguntas[currentPreguntaIndex];
    Debug.Log("Next question: " + currentPregunta.pregunta);
}
}