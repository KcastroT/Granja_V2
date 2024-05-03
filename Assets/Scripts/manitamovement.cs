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

public class manitamovimeinto : MonoBehaviour
{
    //haz que la hija de este objeto solo este encendida 5 segundos despues de llamar a la funcion manita usando deltaTime
    public GameObject manita;
    public float tiempo = 5;
    public bool manitaactiva = false;

    public void mover()
    {
        manitaactiva = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        manita.SetActive(false);
        
    }

    // Update is called once per frame
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