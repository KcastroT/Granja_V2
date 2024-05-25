
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase para manejar el movimiento de la manita animada
public class manitamovimeinto : MonoBehaviour
{
    //Haz que la hija de este objeto solo este encendida 5 segundos despues de llamar a la funcion manita usando deltaTime
    public GameObject manita;
    public float tiempo = 5;
    public bool manitaactiva = false;

    public void mover()
    {
        manitaactiva = true;
    }


    void Start()
    {
        manita.SetActive(false);
        
    }

    //Mueve la manita si esta activa por 5 segundos
    void Update()
    {
        if (manitaactiva)
        {   
            manita.SetActive(true);
            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                manita.SetActive(false);
                manitaactiva = false;
                tiempo = 5;
            }
        }
    }
    
    
    



}