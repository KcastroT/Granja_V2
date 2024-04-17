using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogManager : MonoBehaviour
{
    private Queue<string> sentences;

    public GameObject dialogBox;
    
    public TextMeshProUGUI diaglogText;
    public TextMeshProUGUI nameText;

    public Animator animator;

    public GameObject image;


    
    void Start()
    {
      sentences = new Queue<string>();   
    }   

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialog.name;
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void ApagaTutorial(){
        dialogBox.SetActive(false);
    }



    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            FindObjectOfType<GameManager>().TutorialActive = false;
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //Detiene la corutina actual si el jugador presiona el botón de siguiente antes de que termine de escribirse la oración
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        
        diaglogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            diaglogText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialog()
    {   
        animator.SetBool("IsOpen", false);
        Debug.Log("Fin de la conversación");
    }

    private void Update()
    {

        if(FindObjectOfType<GameManager>().TutorialActive == false)
        {
            image.SetActive(false);
        }else{
            image.SetActive(true);
        }
    }
}
