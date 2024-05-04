/*
Autores:
    Joel Vargas Reynoso
    Fabrizio Martínez Chávez
    Roger Vicente Rendón Cuevas
    Kevin Santiago Castro Torres
    Manuel Olmos Antillón
*/
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Clase para manejar las preguntas y respuestas
public class PreguntasManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public List<TextMeshProUGUI> answerTexts;

    void Start()
    {
        UpdateQuestionAndAnswers("What is your question?", new List<string> { "Answer 1", "Answer 2", "Answer 3", "Answer 4" });
    }

    public void UpdateQuestionAndAnswers(string question, List<string> answers)
    {
        questionText.text = question;

        for (int i = 0; i < answerTexts.Count && i < answers.Count; i++)
        {
            answerTexts[i].text = answers[i];
        }
    }
}