using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vacas : MonoBehaviour
{
    public GameObject vacacontainer;
    public bool eventovaca = false;

    private float tiempotranscurrido = 0;

    // Start is called before the first frame update
    void Start()
    {
        vacacontainer.SetActive(false);
        
    }
    public void ActivarVacas()
    {
        eventovaca = true;
        //audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventovaca == true)
        {
            vacacontainer.SetActive(true);
            //reproduce el audio raiz de sonido
            
        }

        if (tiempotranscurrido <= 11f)
        {
            // Mientras el tiempo transcurrido sea <= 5 segundos, activar todo
            tiempotranscurrido += Time.deltaTime;
        }
        else
        {
            vacacontainer.SetActive(false);
            eventovaca = false;
            tiempotranscurrido = 0;
        }
        
    }

}
