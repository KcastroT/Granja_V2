using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porche : MonoBehaviour
{

    public GameObject Arboles;
    public GameObject Coche;
    public GameObject sonido;
    private AudioSource audioSource;
    public bool eventoporche = false;
    private float tiempotranscurrido = 0;



    // Start is called before the first frame update
    void Start()
    {
        Arboles.SetActive(false);
        Coche.SetActive(false);
        sonido.SetActive(true);
        //get componenet audio source de sonido
        audioSource = sonido.GetComponent<AudioSource>();
        
        
    }

    public void ActivarPorche()
    {
        eventoporche = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventoporche == true)
        {
            Arboles.SetActive(true);
            Coche.SetActive(true);
            //reproduce el audio raiz de sonido
            
        }

        if (tiempotranscurrido <= 11f)
        {
            // Mientras el tiempo transcurrido sea <= 5 segundos, activar todo
            tiempotranscurrido += Time.deltaTime;
        }
        else
        {
            Arboles.SetActive(false);
            Coche.SetActive(false);
            eventoporche = false;
            tiempotranscurrido = 0;
        }
        
    }
}
