
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// La clase DialogManager maneja la visualización y el control de diálogos en el juego.
public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences; // Cola para almacenar las oraciones del diálogo actual.

    public GameObject dialogBox; // GameObject que representa el cuadro de diálogo visual en la UI.
    
    public TextMeshProUGUI diaglogText; // Componente de texto para mostrar la oración actual del diálogo.
    public TextMeshProUGUI nameText; // Componente de texto para mostrar el nombre en el diálogo.

    public Animator animator; // Animator para manejar las transiciones de apertura/cierre del diálogo.

    public GameObject image; // GameObject que puede representar una imagen asociada con el diálogo.

    
    void Start()
    {
        sentences = new Queue<string>(); // Inicializa la cola de oraciones.
    }   

    // Inicia un nuevo diálogo utilizando un objeto Dialog que contiene las oraciones y el nombre.
    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialog.name;
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        FindObjectOfType<GameManager>().ToggleHUD(true, false);

        DisplayNextSentence();
    }

    // Función para desactivar el tutorial, limpiando las oraciones y actualizando el estado en GameManager.
    public void ApagaTutorial(){
        sentences.Clear();
        FindObjectOfType<GameManager>().TutorialActive = false;
        animator.SetBool("IsOpen", false);
    }

    // Muestra la siguiente oración del diálogo, o termina el diálogo si no hay más oraciones.
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); // Detiene cualquier corutina actualmente en ejecución.
        StartCoroutine(TypeSentence(sentence));
    }

    // Corutina que muestra la oración letra por letra.
    IEnumerator TypeSentence(string sentence)
    {
        diaglogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            diaglogText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Finaliza el diálogo y reactiva la interfaz de usuario del juego.
    public void EndDialog()
    {   
        animator.SetBool("IsOpen", false);
        Debug.Log("Fin de la conversación");
        FindObjectOfType<GameManager>().ToggleHUD(true, true);
    }

    // Actualiza la visibilidad de una imagen basada en el estado del tutorial.
    private void Update()
    {
        if (FindObjectOfType<GameManager>().TutorialActive == false)
        {
            image.SetActive(false);
        }
        else
        {
            image.SetActive(true);
        }
    }

    // Desactiva todos los diálogos ocultando el GameObject.
    public void EndAllDialogs()
    {
        animator.SetBool("IsOpen", false);
        gameObject.SetActive(false);
    }

    // Reactiva el GameObject para permitir diálogos.
    public void AllDialogs()
    {
        gameObject.SetActive(true);
    }
}
