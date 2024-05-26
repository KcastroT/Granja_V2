using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elefantes : MonoBehaviour
{
    public GameObject barril;
    public GameObject human;
    public GameObject palanca;
    public GameObject elefante_cont;
    public bool eventoelefante = false;
    private float tiempotranscurrido = 0;




    // Start is called before the first frame update
    void Start()
    {
        barril.SetActive(false);
        human.SetActive(false);
        palanca.SetActive(false);
        elefante_cont.SetActive(false);
    }

    public void ActivarElefante()
    {
        eventoelefante = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventoelefante == true)
        {
            barril.SetActive(true);
            human.SetActive(true);
            palanca.SetActive(true);
            elefante_cont.SetActive(true);
        }

        if (tiempotranscurrido <= 9f)
        {
            // Mientras el tiempo transcurrido sea <= 5 segundos, activar todo
            tiempotranscurrido += Time.deltaTime;
        }
        else
        {
            barril.SetActive(false);
            human.SetActive(false);
            palanca.SetActive(false);
            elefante_cont.SetActive(false);
            eventoelefante = false;
            tiempotranscurrido = 0;
        }
        
    }

    
}
