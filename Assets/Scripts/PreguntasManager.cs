using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// Clase para manejar las preguntas y respuestas
public class PreguntasManager : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public List<Button> answerButtons; // Lista de botones para las respuestas
    public GameObject resultPanel; // Panel para mostrar los resultados
    public GameObject questionPanel; // Panel para mostrar las preguntas
    public TextMeshProUGUI scoreText; // Texto para mostrar el puntaje

    public GameObject correctSoundObject; // GameObject para el sonido de respuesta correcta
    public GameObject incorrectSoundObject; // GameObject para el sonido de respuesta incorrecta

    private AudioSource correctAudioSource; // AudioSource para respuesta correcta
    private AudioSource incorrectAudioSource; // AudioSource para respuesta incorrecta

    private Queue<Question> questionsQueue; // Cola de preguntas
    private int score; // Puntaje
    private int questionsAnswered; // Contador de preguntas contestadas
    private Question currentQuestion; // Pregunta actual

    [System.Serializable]
    public class Question
    {
        public string question;
        public List<string> answers;
        public int correctAnswerIndex; // Índice de la respuesta correcta
    }

    public List<Question> questionsList; // Lista de preguntas iniciales

    void Start()
    {
        questionsQueue = new Queue<Question>(questionsList);
        score = 0;
        questionsAnswered = 0; // Inicializar el contador de preguntas contestadas

        if (correctSoundObject != null)
        {
            correctAudioSource = correctSoundObject.GetComponent<AudioSource>();
        }

        if (incorrectSoundObject != null)
        {
            incorrectAudioSource = incorrectSoundObject.GetComponent<AudioSource>();
        }

        resultPanel.SetActive(false); // Asegurarse de que el panel de resultados esté desactivado al inicio
        ShowNextQuestion();
    }

    public void ShowNextQuestion()
    {
        if (questionsQueue.Count > 0)
        {
            currentQuestion = questionsQueue.Dequeue();
            UpdateQuestionAndAnswers(currentQuestion);
        }
        else
        {
            ShowResults();
            questionPanel.SetActive(false); // Desactivar el panel de preguntas
        }
    }

    public void UpdateQuestionAndAnswers(Question question)
    {
        questionText.text = question.question;

        for (int i = 0; i < answerButtons.Count && i < question.answers.Count; i++)
        {
            int index = i; // Necesario para evitar el problema de cierre de bucle
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.answers[i];
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => AnswerQuestion(index));
        }
    }

    public void AnswerQuestion(int selectedAnswerIndex)
    {
        if (currentQuestion.correctAnswerIndex == selectedAnswerIndex)
        {
            score++;
            if (correctAudioSource != null)
            {
                correctAudioSource.PlayOneShot(correctAudioSource.clip);
            }
        }
        else
        {
            if (incorrectAudioSource != null)
            {
                incorrectAudioSource.PlayOneShot(incorrectAudioSource.clip);
            }
        }

        questionsAnswered++; // Incrementar el contador de preguntas contestadas
        Debug.Log("Preguntas contestadas: " + questionsAnswered);
        Debug.Log("Total de preguntas: " + questionsList.Count);

        if (questionsAnswered >= questionsList.Count)
        {
            ShowResults(); // Mostrar resultados si todas las preguntas han sido contestadas
        }
        else
        {
            ShowNextQuestion();
        }
    }

    public void ShowResults()
    {
        resultPanel.SetActive(true);
        questionPanel.SetActive(false); // Desactivar el panel de preguntas
        scoreText.text = score + "/" + questionsList.Count;
    }
}
