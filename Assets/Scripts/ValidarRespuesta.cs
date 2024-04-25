using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValidarRespuesta : MonoBehaviour
{
    public sistemaPregunta sistemaPregunta;
    public PreguntasManager preguntasManager;

    public bool ValidateAnswer(int n)
    {
        Pregunta currentPregunta = sistemaPregunta.GetCurrentPregunta();
        string userAnswer = currentPregunta.opciones[n];

        bool isCorrect = userAnswer == currentPregunta.respuesta_correcta;

        sistemaPregunta.GetNextPregunta();
        Pregunta nextPregunta = sistemaPregunta.GetCurrentPregunta();
        preguntasManager.UpdateQuestionAndAnswers(nextPregunta.pregunta, nextPregunta.opciones);

        return isCorrect;
    }

        public void Op1(){
        ValidateAnswer(0);
    }

    public void Op2(){
        ValidateAnswer(1);
    }

    public void Op3(){
        ValidateAnswer(2);
    }

    public void Op4(){
        ValidateAnswer(3);
    }
}