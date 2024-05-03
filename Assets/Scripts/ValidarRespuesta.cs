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
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

public class ValidarRespuesta : MonoBehaviour
{
    public sistemaPregunta sistemaPregunta;
    public PreguntasManager preguntasManager;
    public GameObject sonidocorrecto;
    public GameObject sonidoincorrecto;

    private AudioSource sonidoCorrecto; // Para controlar la reproducción del sonido correcto
    private AudioSource sonidoIncorrecto; // Para controlar la reproducción del sonido incorrecto

    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    private int correctAnswerIndex = 0;
    string userAnswer;
    bool isCorrect = false;

    void Start()
    {
        // Obtén los componentes AudioSource de los objetos sonidocorrecto y sonidoincorrecto
        sonidoCorrecto = sonidocorrecto.GetComponent<AudioSource>();
        sonidoIncorrecto = sonidoincorrecto.GetComponent<AudioSource>();
    }

    public bool ValidateAnswer(int n)
    {
        Pregunta currentPregunta = sistemaPregunta.GetCurrentPregunta();
        userAnswer = currentPregunta.opciones[n];

        for (int i = 0; i < 4; i++)
        {
            if (currentPregunta.opciones[i] == currentPregunta.respuesta_correcta)
            {
                correctAnswerIndex = i;
                break;
            }
        }

        isCorrect = userAnswer == currentPregunta.respuesta_correcta;

        // Reproduce el sonido correcto si la respuesta es correcta, y el sonido incorrecto si no lo es
        if (isCorrect)
        {
            sonidoCorrecto.Play();
        }
        else
        {
            sonidoIncorrecto.Play();
        }

        return isCorrect;
    }

    public bool IsCorrectAnswer()
    {
        return isCorrect;
    }

    public string SelectedAnswer()
    {
        return userAnswer;
    }

    IEnumerator ChangeQuestion()
    {
        yield return new WaitForSeconds(4f);
        sistemaPregunta.GetNextPregunta();
        Pregunta nextPregunta = sistemaPregunta.GetCurrentPregunta();
        preguntasManager.UpdateQuestionAndAnswers(nextPregunta.pregunta, nextPregunta.opciones);
        btn1.GetComponent<Image>().color = Color.white;
        btn2.GetComponent<Image>().color = Color.white;
        btn3.GetComponent<Image>().color = Color.white;
        btn4.GetComponent<Image>().color = Color.white;
    }

    public void Op1()
    {
        if (ValidateAnswer(0))
        {

            Debug.Log("Respuesta correcta");
            btn1.GetComponent<Image>().color = Color.green;
        }
        else
        {
            Debug.Log("Respuesta incorrecta");
            btn1.GetComponent<Image>().color = Color.red;
            ChangeCorrectButtonColor();
        }

        StartCoroutine(ChangeQuestion());
    }

    public void Op2()
    {
        if (ValidateAnswer(1))
        {
            Debug.Log("Respuesta correcta");
            btn2.GetComponent<Image>().color = Color.green;
        }
        else
        {
            Debug.Log("Respuesta incorrecta");
            btn2.GetComponent<Image>().color = Color.red;
            ChangeCorrectButtonColor();
        }

        StartCoroutine(ChangeQuestion());
    }

    public void Op3()
    {
        if (ValidateAnswer(2))
        {
            Debug.Log("Respuesta correcta");
            btn3.GetComponent<Image>().color = Color.green;
        }
        else
        {
            Debug.Log("Respuesta incorrecta");
            btn3.GetComponent<Image>().color = Color.red;
            ChangeCorrectButtonColor();
        }

        StartCoroutine(ChangeQuestion());
    }

    public void Op4()
    {
        if (ValidateAnswer(3))
        {
            Debug.Log("Respuesta correcta");
            btn4.GetComponent<Image>().color = Color.green;
        }
        else
        {
            Debug.Log("Respuesta incorrecta");
            btn4.GetComponent<Image>().color = Color.red;
            ChangeCorrectButtonColor();
        }

        StartCoroutine(ChangeQuestion());
    }

    private void ChangeCorrectButtonColor()
    {
        // Assuming correctAnswerIndex is the index of the correct answer
        switch (correctAnswerIndex)
        {
            case 0:
                btn1.GetComponent<Image>().color = Color.green;
                break;
            case 1:
                btn2.GetComponent<Image>().color = Color.green;
                break;
            case 2:
                btn3.GetComponent<Image>().color = Color.green;
                break;
            case 3:
                btn4.GetComponent<Image>().color = Color.green;
                break;
        }
    }

}